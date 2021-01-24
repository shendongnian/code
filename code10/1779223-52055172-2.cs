        public class Attribute
        {
            public string Name { get; set; }
            public string ShortName { get; set; }
            public bool Standard { get; set; }
        }
        public class BaseAttribute : Attribute
        {
            public int Value { get; set; }
        }
        public class Profile<T> where T:Attribute,new ()
        {
            public List<T> AttributeList = new List<T>
            {
                 new T {Name = "Hands", ShortName = "HA", Standard = true},
                 new T {Name = "Arms", ShortName = "AR", Standard = true},
            };
        }
        public class BaseProfile : Profile<BaseAttribute>
        {
            
        }
