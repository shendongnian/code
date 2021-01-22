    public class MyForm : Form
    {
        private MyForm _instance = null;
        private object _lock = new object();
        private MyForm() { }
        public static MyForm Instance
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                        _instance = new MyForm();
                }
            }
        }
    }
