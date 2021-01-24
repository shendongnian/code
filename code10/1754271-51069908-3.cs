    private void btnAdd_Click(object sender, EventArgs e)
    {
        ushort operand1;
        ushort operand2;
    
        if((UInt16.TryParse(txtOperand1.Text, out operand1) &&
            UInt16.TryParse(txtOperand2.Text, out operand2)) == false)
        {
            // MessageBox.Show("not number");
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            label1.Text = "Value must be numeric and > 0";
        }
        else
        {
            label1.Visible = true;
            label1.Text = string.Format("{0:N}", operand1 + operand2).ToString();
        }
    }
