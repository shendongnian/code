    // the property
    public List<Items> ItemsHolder
    {
        get
        {
            object ItemsSession = Session["ItemSession"] as List<Items>;
    
            if (ItemsSession == null)
            {
                ItemsSession = new List<Items>();
                Session["ItemSession"] = ItemsSession;
            }
    
            return (List<Items>)ItemsSession;
        }
    }
