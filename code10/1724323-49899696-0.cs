    using (ShimsContext.Create())
    {
        var client = new ODataClient.Microsoft.Dynamics.CRM.Fakes.ShimSystem();
        IDataAccess dao = new DataAccess.DataAccess(client);
        var salesorders = new List<Salesorder>
        {
            new Salesorder()
        };
        IQueryable<Salesorder> queryableData = salesorders.AsQueryable();
        var queryShim = new Microsoft.OData.Client.Fakes.ShimDataServiceQuery<Salesorder>();
        queryShim.ExpressionGet = () => queryableData.Expression;
        queryShim.ElementTypeGet = () => queryableData.ElementType;
        queryShim.ProviderGet = () => queryableData.Provider;
        queryShim.GetEnumerator = () => queryableData.GetEnumerator();
        DataClient.Microsoft.Dynamics.CRM.Fakes.ShimSystem.SalesordersGet = () => queryShim;
    }
