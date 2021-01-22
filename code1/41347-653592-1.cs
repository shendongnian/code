    protected string MyFunction(int nbrOrders)
    {
        if(nbrOrders>=Config.MAX_ENQUIRY_SALES)
        {
            return "TrueResult";
        }
        else
        {
            return "FalseResult";
        }
    }
