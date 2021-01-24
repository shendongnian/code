    public delegate void myDel();
    public class Service1 : MyService
    {
        private WindowsFormsApp1.Form1 form;
        public Service1()
        {
            this.form = new WindowsFormsApp1.Form1();
        }
        private void SetFormData()
        {
            this.form.Size = new System.Drawing.Size(100, 500);
        }
        public void DoSomeFun()
        {
            this.form.Show();
            myDel del = new myDel(SetFormData);
            this.form.Invoke(del);
        }
    }
