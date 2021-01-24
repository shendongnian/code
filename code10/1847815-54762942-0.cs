     public class ClassExample
        {
            public ClassExample(params string[] values)
            {
                if (values == null || values.Count(p => p != null) != 1) throw new ArgumentException("Just 1 value please");
                if (values.Length > 0) Value1 = values[0];
                if (values.Length > 1) Value2 = values[1];
                // rest of property assignments;
            }
            public string Value1 { get; private set; }
            public string Value2 { get; private set; }
            public string Value3 { get; private set; }
    
        }
    }
