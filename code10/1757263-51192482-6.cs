    public class MyClasses : Collection<MyClass>
        {
            public enum GroupType
            {
                GroupByYear = 0,
                GroupByMonth = 1,
                GroupByWeek = 2
            }
            public MyClasses(IEnumerable<MyClass> classes)
            {
                foreach (var myClass in classes)
                {
                    Add(myClass);
                }
            }
    
            public IEnumerable<IGrouping<int, MyClass>> GroupByYear => this.GroupBy(x => x.Date.Year);
    
            public IEnumerable<IGrouping<int, MyClass>> GroupByMonth => this.GroupBy(x => x.Date.Month);
    
            public IEnumerable<IGrouping<int, MyClass>> GroupByWeek => this.GroupBy(x => x.Date.WeekNumber());
    
            public IEnumerable<IGrouping<int, MyClass>> GetGroupedValue(GroupType groupType)
            {
                var propertyName = groupType.ToString();
                var property = GetType().GetProperty(propertyName);
                return property?.GetValue(this) as IEnumerable<IGrouping<int, MyClass>>;
            }
        }
