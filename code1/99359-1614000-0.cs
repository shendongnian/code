    // the original form
    class MyForm()
    {
         // form public method
         public void MyMethod() { ... }
    }
    // class storing the reference to a form
    class MyOtherClass
    {     
        public static Form MyForm;
        public void ShowForm()
        {
            MyForm = new MyForm();
            MyForm.Show();
        }
    }
    // invoke form public method in this class
    class YetAnotherClass
    {
        public void SomeMethod ()
        {
            MyOtherClass.MyForm.MyMethod();
        }
    }
