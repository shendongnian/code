    // Define enum
    public enum ServiceType : int
    {
        MinimumService = 1,
        NormalService = 2,
        VipService = 99
    }
    // custom method to get my custom text name for each enum type
    public string GetServiceTypeName(ServiceType serviceType)
    {
        string retValue = "";
        switch (serviceType)
        {
            case ServiceType.Print:
                retValue = "We have some services for you";
                break;
            case ServiceType.BookBinding:
                retValue = "We ar glad to meet you";
                break;
            default:
                retValue = "We alywas are ready to make you happy";
                break;
        }
        return retValue;
    }
    // making dictionary (key and value) for dropdown datasource
    public static Dictionary<string, int> GetAllServiceTypeName()
    {
        Dictionary<string, int> dataSource = new Dictionary<string, int>();
        foreach (int item in Enum.GetValues(typeof(ServiceType)))
            dataSource.Add(GetServiceTypeName((ServiceType)item), item);
        return dataSource;
    }
       // bind the dropdown to dictionary
        ddlServiceType.DataSource = GetAllServiceTypeName();
        ddlServiceType.DataBind();
    
       // aspx markup code sample
        <asp:DropDownList ID="ddlServiceType" runat="server" 
            DataTextField="Key" DataValueField="Value">
        </asp:DropDownList>
