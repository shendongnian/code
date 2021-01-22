    class MyClass : MyBaseClass, IMyInterface
    {
        public event EventHandler MyEvent;
        int m_MyField = 1;
        int MyProperty {
            get {
                return m_MyField;
            }
            set {
                m_MyField = value;
            }
        }
        void MyMethod(int myParameter) {
            int _MyLocalVaraible = myParameter;
            MyProperty = _MyLocalVaraible;
            MyEvent(this, EventArgs.Empty);
        }
    }
