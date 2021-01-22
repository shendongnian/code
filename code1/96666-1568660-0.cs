    class Employee
        {
            string _name;
            string _last;
            double _val;
            public Employee(string name, string last, double  val)
            {
                _name = name;
                _last = last;
                _val = val;
            }
            public override bool Equals(object obj)
            {
                Employee e = obj as Employee;
                return e._name == _name;
            }
        }
