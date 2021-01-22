    private NHibernate.Cfg.Configuration _configuration;
    
    [...]
    
    var selector = new MyPropertySelector<MyClass>(_configuration, "MyUniqueKeyGroup");
    criteria.Add(Example.Create(myObject)
                        .SetPropertySelector(selector));
    
    [...]
    
    public class MyPropertySelector<T>: NHibernate.Criterion.Example.IPropertySelector
    {
        private NHibernate.Cfg.Configuration _onfiguration;
        private IEnumerable<NHibernate.Mapping.Column> _keyColumns;
        public MyPropertySelector(NHibernate.Cfg.Configuration cfg, string keyName)
        {
            _configuration = cfg;
            _keyColumns = _configuration.GetClassMapping(typeof(T))
                                    .Table
                                    .UniqueKeyIterator
                                    .First(key => key.Name == keyName)
                                    .ColumnIterator);
        }
    
        public bool Include(object propertyValue, string propertyName, IType type)
        {
             return _configuration.GetClassMapping(typeof(T))
                              .Properties
                              .First(prop => prop.Name == propertyName)
                              .ColumnIterator
                                  .Where(col => !col.IsFormula)
                                  .Cast<NHibernate.Mapping.Column>()
                                  .Any(col => _keyColumns.Contains(col)))
        }
    }
