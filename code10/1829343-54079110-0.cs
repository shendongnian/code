    private View _agentSummary;
    
    public void LoadOrderPage()
    {
        Android.Support.V4.View.ViewPager SummaryWalletSwitcher = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.SummaryWalletSwitcher);
    
        List<View> viewlist = new List<View>();
        _agentSummary = LayoutInflater.Inflate(Resource.Layout.AgentSummary, null, false);
        viewlist.Add(_agentSummary);
        viewlist.Add(LayoutInflater.Inflate(Resource.Layout.AgentWallet, null, false));
        SummaryWalletAdapter ViewSwitchAdapter = new SummaryWalletAdapter(viewlist);
        SummaryWalletSwitcher.Adapter = ViewSwitchAdapter;
    
        LoadAgentInfo(null, null);
    
        Timer AgentInfo_Timer = new Timer();
        AgentInfo_Timer.Interval = 1000;
        AgentInfo_Timer.Elapsed += LoadAgentInfo;
        AgentInfo_Timer.Enabled = true;
    }
    
    public void LoadAgentInfo(object sender, ElapsedEventArgs e)
    {
        TextView TextView1 = _agentSummary.FindViewById<TextView>(Resource.Id.txtPortfolioValue);      
        TextView1.Text = "This is TextView 1";
    }
