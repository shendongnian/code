    public class LocationSelector
    {
        public class LocationFilter
        {
            public List<string> Criteria1 { get; set; }
            public List<string> Criteria2 { get; set; }
            public List<string> Criteria3 { get; set; }
    
            // We use this method to transfor a list of values
            //  (Criteria1) in a SINGLE predicate
            private Func<MyType, bool> Criteria1ToPredicate()
            {
                if (Criteria1 == null) return (obj) => true;
                
                // if Criteria1 is a simple list of strings,
                // you can use contains
                return (obj) => Criteria1.Contains(obj.Criteria1.Value);
            }
    
            private Func<MyType, bool> Criteria2ToPredicate()
            {
                if (Criteria2 == null) return (obj) => true;
                
                // if you cannot use contains, you can use Any
                return (obj) => Criteria2.Any(critVal => obj.Criteria2 == critVal);
            }
    
            private Func<MyType, bool> Criteria3ToPredicate()
            {
                if (Criteria3 == null) return (obj) => true;
                
                return (obj) => Criteria3.Any(crit3 => obj.Criteria3.Value);
            }
    
            public Func<MyType, bool> ToPredicate()
            {
                var pred1 = Criteria1ToPredicate();
                var pred2 = Criteria2ToPredicate();
                var pred3 = Criteria3ToPredicate();
                return (obj) => pred1(obj) && pred2(obj) && pred3(obj);
            }
        }
    
        public string Name { get; set; }
        public List<LocationFilter> Filter { get; set; }
    
        // This method puts the different filters in OR
        public Func<MyType, bool> ToPredicate()
        {
            var predicates = Filter.Select(f => f.ToPredicate()).ToList();
    
            return (obj) => predicates.Any(predicate => predicate(obj));
        }
    }
    
    
    Usage:
    
    // given a List<LocationSelector> coming from the Json
    // and a List<MyType> as an input
    
    public List<MyType> FilterByLocation(LocationSelector selector, List<MyType> source)
    {
        Func<MyType, bool> locationSelector = selector.ToPredicate();
    
        return source.Where(obj => locationSelector(obj)).ToList();
    }
    
    public Dictionary<string, List<MyType>>(List<LocationSelector> selectors, List<MyType> source)
    {
        return selectors.ToDictionary(
            locSelector => locSelector.Name,
            locSelector => FilterByLocation(locSelector, source)
        );
    }
