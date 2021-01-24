        protected void CostEstimation()
        {
            decimal Temp = 0;
            decimal Temp2 = 0;
            decimal Temp3 = 0;
            decimal Temp4 = 0;
            if (tbTextBoxTotal1.Text == "")
            {
                tbTextBoxTotal1.Text = "0";
            }
            if (tbTextBoxTotal2.Text == "")
            {
                tbTextBoxTotal2.Text = "0";
            }
            if (tbTextBoxTotal3.Text == "")
            {
                tbTextBoxTotal3.Text = "0";
            }
            try
            {
                Temp = Convert.ToDecimal(string.Format("{0:0.00}", tbTextBoxTotal1.Text));
                Temp2 = Convert.ToDecimal(string.Format("{0:0.00}", tbTextBoxTotal2.Text));
                Temp3 = Convert.ToDecimal(string.Format("{0:0.00}", ttbTextBoxTotal3.Text));
                Temp4 = Temp + Temp2 + Temp3;
            }
            catch (Exception)
            {
            }
            tbCombinedTotals.Text = Temp4.ToString();
        }
