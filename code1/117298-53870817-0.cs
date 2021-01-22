    static class FormService{
        /*
         * Members
         */
        private static Dictionary<string, Form> _forms = new Dictionary<string, Form>();
        private static Dictionary<string, Type> _types = new Dictionary<string, Type>();       
        private static Form opened_ = null;
        /*
         * Properties
         */
        public static Form Opened
        /*
         * Methods
         */
        public static void register(string className, Type type){
            if (_types.ContainsKey(className))throw new Exception("Form already registered");
            _forms.Add(className, Activator.CreateInstance(type));
            _types.Add(className, type);
            
        }
        // use with Convert.ChangeType
        public static Type getFormType(string className){
            return _types[className];
        }
        public static void open(string className){
            if (opened_ != null){
                opened_.Hide();
            }
            opened_ = _forms[className];
            opened_.ShowDialog(); // show dialog will block main menu actions
        }
    }
