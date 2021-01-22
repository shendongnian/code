        public partial class App
        {
            private static Window _myWindow;
    
            public static Window1 MyWindow
            {
                get
                {
                    if (_myWindow == null)
                        _myWindow = new Window1();
                    return _myWindow;
                }
           }
        }
             
