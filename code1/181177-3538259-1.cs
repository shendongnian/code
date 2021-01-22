    public class MyFancyContext : ApplicationContext
    {
        private LogOnForm logOnForm;
        private ShellForm shellForm;
        public MyFancyContext()
        {
            this.logOnForm = new LogOnForm();
            this.MainForm = this.logOnForm;
        }
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (this.MainForm == this.logOnForm
                && this.logOnForm.DialogResult == DialogResult.OK)
            {
                // Assume the log on form validated credentials
                this.shellForm = new ShellForm();
                this.MainForm = this.shellForm;
                this.MainForm.Show();  
            }
            else
            {
                // No substitution, so context will stop and app will close
                base.OnMainFormClosed(sender, e);
            }
        }
    }
