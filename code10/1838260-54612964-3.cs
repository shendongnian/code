    public partial class Form1 : Form
    {
        Form2 settingsWindow;
        public Form1()
        {
            InitializeComponent();
        }
        private void SettingsWindow_HandleCreated(object sender, EventArgs e)
        {
            var dt1 = new SampleTable1();
            var dt2 = new SampleTable2();
            settingsWindow.FillTree(dt1, dt2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            settingsWindow = new Form2();
            settingsWindow.HandleCreated += SettingsWindow_HandleCreated;
            settingsWindow.ShowDialog();
        }
    }
