        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setCheckBoxValue();   
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setCheckBoxValue();
        }
        private void setCheckBoxValue()
        {
            int finalPrice = 0;
            if (radioButton1.Checked == true)
            {
                finalPrice = finalPrice + 75;
            }
            else if (radioButton2.Checked == true)
            {
                finalPrice = finalPrice + 87;
            }
            textBox1.Text = finalPrice.ToString("C");            
        }
