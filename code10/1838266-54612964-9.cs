    public partial class Form1 : Form
    {
        Form2 settingsWindow;
        SampleTable1 dt1;
        SampleTable2 dt2;
        int groupid = 1;
        int userid = 101;
        public Form1()
        {
            InitializeComponent();
            dt1 = new SampleTable1();
            dt2 = new SampleTable2();
            dt1.AddGroup(groupid);
            dt2.AddUser(groupid, userid++);
            dt2.AddUser(groupid, userid++);
            dt1.AddGroup(++groupid);
            dt2.AddUser(groupid, userid++);
            dt2.AddUser(groupid, userid++);
            dt2.AddUser(groupid, userid++);
        }
        private void SettingsWindow_HandleCreated(object sender, EventArgs e)
        {
            settingsWindow.FillTree(dt1, dt2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            settingsWindow = new Form2(this);
            settingsWindow.HandleCreated += SettingsWindow_HandleCreated;
            settingsWindow.ShowDialog();
        }
        public void UpdateData(string groupname)
        {
            dt1.AddGroup(++groupid, groupname);
            dt2.AddUser(groupid, userid++);
            dt2.AddUser(groupid, userid++);
            settingsWindow.FillTree(dt1, dt2);
        }
    }
