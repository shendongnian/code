    public partial class MainForm : Form
    {
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            // Here we can get the checked state of the checkbox on the Settings form
            if (settings.CheckBoxIsChecked)
            {
                Opacity = 0.9;
            }
        }
        // Rest of form code omitted...
    }
