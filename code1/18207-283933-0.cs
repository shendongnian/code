    public class MainForm : Form
    {
    }
    public class OtherForm : Form
    {
        protected MainForm MainForm { get; set; }
        public OtherForm(MainForm mainForm) : base()
        {
            this.MainForm = mainForm;
        }
    }
