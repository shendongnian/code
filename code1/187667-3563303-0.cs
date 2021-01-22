    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            _checkBoxes = new CheckBox[] { _checkBox1, _checkBox2, _checkBox3, _checkBox4 };
    
            foreach (var checkBox in _checkBoxes)
                checkBox.CheckedChanged += new EventHandler(ShowCheckedCheckboxes);
        }
    
        void ShowCheckedCheckboxes(object sender, EventArgs e)
        {
            string message = string.Empty;
    
            for (int i = 0; i < _checkBoxes.Length; i++)
            {
                if (_checkBoxes[i].Checked && _checkBoxes[i].Enabled)
                {
                    message += string.Format("boxes[{0}] is clicked\n", i);
                }
            }
    
            MessageBox.Show(message);
        }
    
        CheckBox[] _checkBoxes;
    }
