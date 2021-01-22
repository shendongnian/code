        public string Name { get; set; }
        public int Age { get; set; }
        public override bool Equals(object obj)
        {
            var objAsPerson = obj as Person;
            if (obj == null)
            {
                return false;
            }
            if (this.Name != objAsPerson.Name)
            {
                return false;
            }
            if (this.Age != objAsPerson.Age)
            {
                return false;
            }
            return true;
        }
    }
