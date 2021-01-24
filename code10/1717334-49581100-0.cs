    public class YourForm : Form
    {
        public YourForm()
        {
            InitializeComponents();
            somePanel.BackColorChanged += SomePanel_OnBackColorChanged;
        }
        public void SomePanel_OnBackColorChanged(object sender, EventArgs e)
        {
            //Back color has changed, do something
        }
    }
