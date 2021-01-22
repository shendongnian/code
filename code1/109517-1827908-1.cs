    public static string GetFormattedOrderId(object dataItem)
    {
        DataRow row = (DataRow) dataItem;
        return String.Format("WW{0:N7}", row["OrderId"]);      
    }
