    public class MyForm : Form
    {
        //this is used to keep a reference of the single
        //instance of this class
        private static MyForm _instance; 
        //your constructor is private, this is important.
        //the only thing that can access the constructor is 
        //the class itself.
        private MyForm()
        {
            //do stuff
        }
        public static MyForm GetInstance()
        {
            //the check to IsDisposed is important
            //if the form is closed, the _instance variable
            //won't be null, but if you return the closed 
            //form (ie, disposed form) any calls to the form
            //class (ie, Show()) will throw in exception.
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new MyForm();
            }
            return _instance;
        }
        //other code
    }
