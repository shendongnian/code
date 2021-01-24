    public void Subtract()
        {
            int a, b,c,d;
            bool isAValid = int.TryParse(txttotalamount.Text, out a);
            bool isBValid = int.TryParse(txtpaidamount.Text, out b);
           
            if (isAValid && isBValid)
            {
                string e = (a - b).ToString();
                txtpendingamount.Text = (e).ToString();
            }
    
     bool isCValid = int.TryParse(txtpendingamount.Text,out c);
            bool isDValid = int.TryParse(txtcreditamountpaid.Text, out d);
    
            if (isCValid && isDValid)
            {
                string f=(c-d).ToString();
                txtpendingamount.Text = (f).ToString();
            }  
            else
            {
                txtpendingamount.Text = "invalid Input";
            }
        }
