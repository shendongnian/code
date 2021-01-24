    namespace Group_Project_Final
    {
        public partial class Form2 : Form
        {
            Dictionary<string, double> interestRates;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                interestRates = new Dictionary<string, double>();
                interestRates.Add("DBS", 1.60);
                interestRates.Add("OCBC", 1.65);
                interestRates.Add("UOB", 1.55);
                interestRates.Add("May Bank", 1.62);
                interestRates.Add("HSBC", 1.58);
                interestRates.Add("RHB", 1.68);
                
                listBox1.Items.Clear();
                listBox1.Items.Add("Bank\t\tRates");
                foreach(KeyValuePair<string, double> entry in interestRates)
                {
                    listbox1.Items.Add($"{entry.Key}\t\t{entry.Value:0.##}%");
                }
    
            }
    
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                //order interest rates either from high to low (descending)
                interestRates.OrderByDescending(item => item.Value);
                //or from low to high
                interestRates.OrderBy(item => item.Value);
            }
        }
    }
