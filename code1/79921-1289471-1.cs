    public void MakePayment(string szAmountDue)
    {
        lblTotalDueValue.Text = szAmountDue;
        mdlPopupPayment.Show();
    }
