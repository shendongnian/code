    public long? ClientId
        {
            get
            {
                long? result = null;
                if (Request.QueryString[QueryStringConstants.ClientId] != null)
                    result = Convert.ToInt64(Request.QueryString[QueryStringConstants.ClientId]);
    
                return result;
            }
        }
    
    
        public DateTime? ItemPurchasedDate
        {
            get
            {
                DateTime? result = null;
                if (Request.QueryString[QueryStringConstants.ItemPurchasedDate] != null)
                    result = Convert.ToDateTime(Request.QueryString[QueryStringConstants.ItemPurchasedDate]);
    
                return result;
            }
        }
