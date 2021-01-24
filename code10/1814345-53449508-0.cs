     private void btnDisplay_Click(object sender, EventArgs e)
            {
                int numOrg = Convert.ToInt32(txtNumOrg.Text);
                double numberToConvert = double.Parse(txtDailyIncrease.Text); // percent
    
                double convertToDecimal = (numberToConvert / 100);
    
                var result = double.Parse(txtNumOrg.Text);
                while (numOrg <= 10)
                {
                    result += convertToDecimal * result;
                    listBox1.Items.Add(result);
    
                    numOrg++;
                }
    
    
    
            }
