    btnPtoPay.Click += delegate
    {
        List<LineItem> selectedList = new List<LineItem>();
    
        for (int x = 0; x < tableGrid.ChildCount; x++)
        {
            var checkbox = (CheckBox)tableGrid.GetChildAt(x).FindViewById(Resource.Id.txtCellFive);
            var tvSelectedAmount = (TextView)tableGrid.GetChildAt(x).FindViewById(Resource.Id.txtCelltwo);
            var tvAmountPaid = (TextView)tableGrid.GetChildAt(x).FindViewById(Resource.Id.txtCelltwo);
            decimal totalM = 0; 
            if (checkbox.Checked)
            {                        
                totalM = totalM+ Convert.ToDecimal(tvSelectedAmount.Text);   
                //Here how to get selected item, with all fields
                double selectedAmount = double.Parse(tvSelectedAmount.Text);
                double amountPaid = double.Parse(tvAmountPaid);
    
                selectedList.Add(new LineItem(totalM, amountPaid, selectedAmount));
            }
        };
    
        var fragmentTx = Activity.SupportFragmentManager.BeginTransaction();
        var feePay = new FeePaymentFragment(selectedList);
        fragmentTx.Replace(Resource.Id.crealtabcontent, feePay, "feedPayFragmentTag").AddToBackStack("feePayfrg");
        fragmentTx.Commit();
    };
