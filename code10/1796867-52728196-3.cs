    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{\"auctionInfo\":[{\"IDEF\":224454585435,\"itemData\":2,\"buyNowPrice\":100},{\"IDEF\":224454839937,\"itemData\":0,\"buyNowPrice\":200},{\"IDEF\":315779793672,\"timestamp\":1539055787,\"formation\":\"f352\",\"Price\":100,\"assetrd\":1,\"rating\":0,\"buyNowPrice\":300}]}";
            dynamic theObject = Newtonsoft.Json.Linq.JObject.Parse(json);
    		dynamic auctionInfo = (Newtonsoft.Json.Linq.JArray)theObject.auctionInfo;
            var theFirstItem = auctionInfo[0];
    		var idef = theFirstItem.IDEF;
    		var price = theFirstItem.buyNowPrice;
    		Console.WriteLine(string.Format("IDEF: {0}, Price: {1}",idef,price));
    	}
    }
