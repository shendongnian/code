    public partial class Form1: Form
    {
        CommManager comm;
        public Form1()
        {
            InitializeComponent();
            comm = new CommManager();
            comm.OnFramePopulated += new EventHandler(updateTextBox);
        }
        private void updateTextBox(object sender, EventArgs ea)
        {
            //update Textbox
        }
    }
    class CommManager
    {
        public EventHandler OnFramePopulated;
        public void PopulateFrame()
        {
            OnFramePopulated(this, null);
        }
    }
