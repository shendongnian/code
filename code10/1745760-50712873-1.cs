    public partial class Form1 : Form
    {
        public Dictionary<int, HoroscopeData> Horoscope = new Dictionary<int, HoroscopeData>();
        public Form1()
        {
            InitializeComponent();
            Horoscope.Add(1, new HoroscopeData("Aris"));
            Horoscope.Add(2, new HoroscopeData("Libra"));
            Horoscope.Add(3, new HoroscopeData("Leo"));
            //adding items in combobox, with tag which is associated with our main data
            //  so we can easily fetch prediction out of it whenever selection changes
            foreach(int tag in Horoscope.Keys)
            {
                CmbItem item = new CmbItem(Horoscope[tag].sign, tag);
                comboBox1.Items.Add(item);
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //here on combobox selection, we are fetching predictions of selected sign
            // and add them in listbox
            CmbItem selectedItem = (CmbItem)(((ComboBox)sender).SelectedItem);
            List<string> predictions = Horoscope[selectedItem.tag].prediction;
            listBox1.Items.Clear();
            foreach (string pre in predictions)
                listBox1.Items.Add(pre);
        }
    }
