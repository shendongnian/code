    static void Main(string[] args)
    {
       ExtractCustomersToBeMarked ectm = new ExtractCustomersToBeMarked(null, new CampaignRepository());
       ectm.ExtractCustomers().Wait();
    }
