    public class ItemSourceProvider
        {
            public IEnumerable<ValueText<int>> GetValues(object o)
            {
                if (o == null) return null;
    
                switch (o.ToString().ToUpper())
                {
                    case "PARAM":
                    {
                        return new List<ValueText<int>>() 
                        {
                            new ValueText<int>{Value = 1, Text = "YES"},
                            new ValueText<int>{Value = 2, Text = "PARTIALLY"},
                            new ValueText<int>{Value = 3, Text = "NO"}
                        };
                    }
                    default: return null;
                }
            }
        }
    
        public class ValueText<T>
        {
            public string Text { get; set; }
            public T Value { get; set; }
        }
