    class CultureItem
    {
        public string Name { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }
    public partial class MainForm : Form
    {
        private CultureItem[] culutures = new CultureItem[]
        {
            new CultureItem() {Name = "Default", CultureInfo = new CultureInfo("en-US")}, 
            new CultureItem() {Name = "Italy", CultureInfo = new CultureInfo("it-IT")}, 
            new CultureItem() {Name = "Japan", CultureInfo = new CultureInfo("ja-JP")}
        };
        public MainForm()
        {
            InitializeComponent();
            comboBox1.DataSource = culutures;
            comboBox1.DisplayMember = "Name";
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedItem as CultureItem;
            if (selected != null)
            {
                Thread.CurrentThread.CurrentUICulture = selected.CultureInfo;
                ApplyLocalization();
            }
        }
        public void ApplyLocalization()
        {
            button1.Text = Properties.Resources.button;
        }
    }
