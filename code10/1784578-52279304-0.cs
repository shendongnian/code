    PaidOutReason paid = new PaidOutReason(trnprt, apiParameters);
    paid.btnSave.Click += (ss, ee) => 
    {
        PopUpBanks popu = new PopUpBanks(this);
        popu.Show();
    };
    paid.Show();
