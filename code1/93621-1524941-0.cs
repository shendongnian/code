    public class DataType
    {       
        ...        
        private string _typeOfContent;
        public virtual Type TypeOfContent
        {
            get { return Type.GetType(_typeOfContent); }
            set { _typeOfContent = value.FullName; }
        }   
    }
    ...
    public class DataTypeMap : ClassMap<DataType>
    {
        Map(x => x.TypeOfContent)
           .Access.CamelCaseField(Prefix.Underscore)
           .CustomType<string>();
    }
