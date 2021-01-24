    Base _base = new Base() { BaseProperty = "Hello World" };
    House _house = new House(_base);
      public class Base
        {
            public string BaseProperty { get; set; }
        }
        public class House : Base
        {
            public House(Base _base)
            {
                foreach (PropertyInfo property in _base.GetType().GetProperties())
                {
                    PropertyInfo propinfo = _base.GetType().GetProperty(property.Name);
                    propinfo.SetValue(this, property.GetValue(_base, null), null);
                }
            }
            public string HouseProp { get; set; }
        }
