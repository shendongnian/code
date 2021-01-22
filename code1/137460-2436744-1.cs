    public class Foo
    {
        private string name;
        private string surname;
    
        [MyPropertyAttribute(MyPropertyAttribute.VisibilityOptions.visible)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    
        [MyPropertyAttribute(MyPropertyAttribute.VisibilityOptions.invisible)]
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
    
    }
