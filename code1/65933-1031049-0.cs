    class MyClass {
        private string _name;
        // standard constructor, so that we can make MyClass's without troubles
        public MyClass(string name) {_name = name}
        public MyClass(MyClass old) {
            _name = old._name;
            // etc...
        }
    }
