    public enum CustomerType
        {
            Starndard = 0,
            Trade = 1
        }
    
    ddCustomerTypes.DataSource = (new Domain.CustomerType()).ToDictionary();
    ddCustomerTypes.DataBind();
