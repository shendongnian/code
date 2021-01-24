    private void txtcreditamountpaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            Subtract(true);
        }
        public void Subtract(bool isCreditAmount = false)
        {
            int a, b,c,d;
            bool isAValid = int.TryParse(txttotalamount.Text, out a);
            bool isBValid = int.TryParse(txtpaidamount.Text, out b);
            bool isCValid = int.TryParse(txtpendingamount.Text,out c);
            bool isDValid = int.TryParse(txtcreditamountpaid.Text, out d);
            if (isAValid && isBValid && !isCreditAmount)
            {
                string e = (a - b).ToString();
                txtpendingamount.Text = (e).ToString();
            }
            else if (isCValid && isDValid)
            {
                string f=(c-d).ToString();
                txtpendingamount.Text = (f).ToString();
            }  
            else
            {
                txtpendingamount.Text = "invalid Input";
            }
        }
