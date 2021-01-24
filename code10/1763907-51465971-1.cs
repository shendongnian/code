    //Point 1
    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        bool bTotalResult = false;
        switch (item.ItemId)
        {
            case Resource.Id.action_next:
                bTotalResult = Task.Run(() => ShowPayMentTypeDialog()).Result;
                // point 3
                return true;
            default:
                // point 3
                return base.OnOptionsItemSelected(item);
        }
    }
    // point 4
    private bool ShowPayMentTypeDialog()
    {
        bool bResult = false;
        try
        {
            LayoutInflater layoutInflater = LayoutInflater.From(this);
            View view = layoutInflater.Inflate(Resource.Layout.lyt_cash_credit_popup, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<Spinner>(Resource.Id.spnrPaymentTerms);
            List<cls_spinner_adapter> resultsWayNo = new List<cls_spinner_adapter> {
            new cls_spinner_adapter {SZ_SPINNER_TEXT ="CASH"},
           new cls_spinner_adapter {SZ_SPINNER_TEXT ="CREDIT" } };
            CommonSpinnerAdapter paymentAdapter = new CommonSpinnerAdapter(this, resultsWayNo);
            userdata.Adapter = paymentAdapter;
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("OK", delegate
            {
                if (resultsWayNo[userdata.SelectedItemPosition].SZ_SPINNER_TEXT == "CASH")
                {
                    cls_statics.B_IS_PROMOMAYMANET_CASH = true;
                }
                else
                {
                    cls_statics.B_IS_PROMOMAYMANET_CASH = false;
                }
                bResult = true;
            })
            .SetNegativeButton("Cancel", delegate
            {
                cls_statics.B_IS_PROMOMAYMANET_CASH = false;
                bResult = true;
                alertbuilder.Dispose();
            });
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();
        }
        catch
        {
        }
        // point 3
        return bResult;
    }
