    public partial class Form1 : Form
    {
        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.listBox1.Items.Add(item.ToString());
            }
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string pname = this.listBox1.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }
       
        public Form1()
        {
            InitializeComponent();
            listAllPrinters();
        }
    }
    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
    }
}
