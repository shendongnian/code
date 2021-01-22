    class SomeClass
    {
        public delegate void UpdateLabel(string value);
        public event UpdateLabel OnLabelUpdate;
        public void Process()
        {
            if (OnLabelUpdate != null)
            {
                OnLabelUpdate("hello");
            }
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateLabelButton_Click(object sender, EventArgs e)
        {
            SomeClass updater = new SomeClass();
            updater.OnLabelUpdate += new SomeClass.UpdateLabel(updater_OnLabelUpdate);
            updater.Process();
        }
        void updater_OnLabelUpdate(string value)
        {
            this.LabelToUpdateLabel.Text = value;
        }
    }
