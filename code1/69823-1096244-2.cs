    class ParameterizedProperty<TPropertyType, TIndexType> {
         Func<TIndexType, TPropertyType> getter;
         Action<TIndexType, TPropertyType> setter;
         public ParameterizedProperty(Func<TIndexType, TPropertyType> getter,
                                      Action<TIndexType, TPropertyType> setter) {
            this.getter = getter;
            this.setter = setter;
         }
         public TPropertyType this[TIndexType index] {
            get { return getter(index); }
            set { setter(index, value); }
         }   
    }
    class MyType {
        private ParameterizedProperty<string, int> prop =
            new ParameterizedProperty<string, int>(getprop, setprop);
        public ParameterizedProperty<string, int> Prop { get { return prop; } }
        string getter(int index) {
            // return the stuff
        }
        void setter(int index, string value) {
            // set the stuff
        }
    }
    MyType test = new MyType();
    test.Prop[0] = "Hello";
    string x = test.Prop[0];
