    //designer code excluded
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = listBox1;
            
            propertyGrid1.PropertyValueChanged += delegate(object s, PropertyValueChangedEventArgs args)
            {
                MessageBox.Show("Invalidate Me!");
            };
        }
    }
