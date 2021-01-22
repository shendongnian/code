    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace CalculateForm
    {
        public partial class FormCalculate : Form
        {
            List<int> listInt = new List<int>();
        
            public FormCalculate()
            {
                InitializeComponent();
            }
            private void btnAddNum_Click(object sender, EventArgs e)
            {
                listInt.Add(Convert.ToInt32(txtAddNum.Text));
                txtAddNum.Clear();
                listBoxAddNum.Items.Clear();
                 
                for (int i = 0; i < listInt.Count; i++)
                {
                    listBoxAddNum.Items.Add(listInt[i]);
                }
            }
            private void btnCalculate_Click(object sender, EventArgs e)
            {
                CalculateService.Service1SoapClient client = new CalculateService.Service1SoapClient();
                CalculateService.ArrayOfInt arrayOfInt = new CalculateService.ArrayOfInt();
            
                arrayOfInt.AddRange(listInt);
                int result = client.CalcluateSum(arrayOfInt);
                txtResult.Text = Convert.ToString(result);
            }
        }
    }
