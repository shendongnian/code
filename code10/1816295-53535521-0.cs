    public partial class Form1 : Form
    {
        List<string> cars = new List<string>()
        {
            "Mazda 3",
            "Mazda 6",
            "VW Polo",
            "VW Golf"
        };
        List<string> Mazda3 = new List<string>()
        {
            "12-04-2008",
            "14-03-2010",
            "20-05-2012",
        };
        List<string> Mazda6 = new List<string>()
        {
            "12-08-2012",
            "14-07-2014",
            "03-09-2016",
        };
        List<string> VWPolo = new List<string>()
        {
            "Some Date",
            "Some Date",
            "Some Date",
        };
        List<string> VWGolf = new List<string>()
        {
            "Some Date",
            "Some Date",
            "Some Date",
        };
        List<List<string>> ServiceLists = new List<List<string>>();
        public Form1()
        {
            InitializeComponent();
            ServiceLists.Add(Mazda3);
            ServiceLists.Add(Mazda6);
            ServiceLists.Add(VWPolo);
            ServiceLists.Add(VWGolf);
            Cars_listBox.DataSource = cars;
        }
        private void Cars_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceRecords_listBox.DataSource = ServiceLists[Cars_listBox.SelectedIndex];
        }
    }
