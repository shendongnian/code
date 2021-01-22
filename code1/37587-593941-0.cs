    public class Person{
        #region variables
        private string _name = String.Empty;
        private string _surname = String.Empty;
        #region properties
        public string Name{
            get{
                 return _name;
            }
        }
        public string Surname{
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }
    }
