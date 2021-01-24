    class a
    {
        private void aa()
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.b();
        }
    }
    public partial class Form2 : Form
    {
        public void b()
        {
            Action a = delegate
            {
                UpdateControls();
            };
            MethodInvoker Invoker = new MethodInvoker(a);
            if (InvokeRequired)
                this.Invoke(Invoker);
            else
                a();
        }
        public void UpdateControls()
        {
            textbox1.Text = "xyz";
        }
    }
