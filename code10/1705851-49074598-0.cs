    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
    ...
        using(var context = new FundContext(_options)){
            GetFundFromWebAndSavetoDB(context);
            PopulateFundLists(context);  
        }
    ...
    }
