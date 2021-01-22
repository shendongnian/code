        void foo(string NameOfControl)
        {
            MyBaseControl ctl = null;
            ctl = (MyBaseControl) Assembly.GetExecutingAssembly().CreateInstance(typeof(MyBaseControl).Namespace + "." + NameOfControl);
        }
