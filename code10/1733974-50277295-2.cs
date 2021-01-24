    public partial class Form1 : Form
    {
        private XDocument _xmlDoc;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "animals.xml"));
            FillComboBox();
            comboBox1.SelectedIndexChanged += ComboBox1OnSelectedIndexChanged;
        }
        private void ComboBox1OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            var cmb = (ComboBox)sender;
            var selectedIndex = cmb.SelectedIndex;
            var selectedValue = cmb.SelectedValue;
            if (_xmlDoc.Root == null) return;
            var animal = (from el in _xmlDoc.Root.Elements("Anim")
                          where (string)el.Attribute("id") == selectedValue.ToString()
                          select el);
            var imagePath = animal.Select(x => x.Element("Image").Value).FirstOrDefault();
            pictureBox1.ImageLocation = @imagePath;
            txtName.Text = cmb.GetItemText(this.comboBox1.SelectedItem);
            var description = animal.Select(x => x.Element("Description").Value).FirstOrDefault();
            txtDescription.Text = description;
            var itemOne = animal.Select(x => x.Element("item1").Value).FirstOrDefault();
            txtItem.Text = itemOne;
        }
        void FillComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.DataSource = _xmlDoc.Root.Elements()
                .Select(e => new { Id = e.Attribute("id").Value, Name = e.Element("Name").Value })
                .ToList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }
    }
