    try 
    {
        WooRestAPI rest = new WooRestAPI(baseUrl, key, secret);
        WCObject wc = new WCObject(rest);
        int pageNum = 1;
        while (true) 
        {
            try 
            {
                var page = pageNum.ToString();
                var getOrders = await wc.Order.GetAll(new Dictionary < string, string > () {
                    {
                        "page", page
                    }, {
                        "per_page", "50"
                    }
                });
                if (getOrders.Count > 0) 
                {
                    ExtractWooData(getOrders);
                    pageNum++;
                } 
                else 
                {
                    break;
                }
            } 
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
        WriteToConsole(orders);
        WriteToFile(orders, outputPath);
    } 
    catch (Exception e) 
    {
        throw new Exception(e.Message);
    }
