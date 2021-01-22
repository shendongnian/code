    class ParameterizedProperty<TProperty, TIndex> {
         private Func<TIndex, TProperty> getter;
         private Action<TIndex, TProperty> setter;
         public ParameterizedProperty(Func<TIndex, TProperty> getter,
                                      Action<TIndex, TProperty> setter) {
            this.getter = getter;
            this.setter = setter;
         }
         public TProperty this[TIndex index] {
            get { return getter(index); }
            set { setter(index, value); }
         }   
    }
    class MyType {
        public MyType() {
            prop = new ParameterizedProperty<string, int>(getProp, setProp);
        }
        private ParameterizedProperty<string, int> prop;
        public ParameterizedProperty<string, int> Prop { get { return prop; } }
        private string getProp(int index) {
            // return the stuff
        }
        private void setProp(int index, string value) {
            // set the stuff
        }
    }
    MyType test = new MyType();
    test.Prop[0] = "Hello";
    string x = test.Prop[0];
