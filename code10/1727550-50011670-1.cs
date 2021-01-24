    class Form1 : Form
    {
        ...
        Form2 form = new Form2();
        void someFunction()
        {
            form.ShowDialog();
            myControl.Text = form.SomeText;
        }
    }
    
    class Form2 : Form
    {
        ...
        public string SomeText { get; set; }
        void someFunction()
        {
            SomeText = "bla";
        }
    }
