    public partial class Form1 : Form
    {
    
        public double tboxvalue;
        private string exportdata;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnClicker_Click(object sender, EventArgs e)
        {
            Functions.EE(this);
        }
        private void txtData_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = ((CheckBox)sender).Checked;
    
            if (@checked.ToString() == "True")
            {
                exportdata = "Yes";
                tboxvalue = Convert.ToDouble(this.txtData.Text);
                System.Diagnostics.Debug.WriteLine(tboxvalue.ToString());
            }
            else
                exportdata = "No";
        }
    }
    class Functions
    {
        public static void EE(Form1 f1)
        {
            System.Diagnostics.Debug.WriteLine(f1.tboxvalue.ToString());
        }
    }
