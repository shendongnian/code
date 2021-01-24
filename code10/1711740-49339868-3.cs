    try 
    {
        WooRestAPI rest = new WooRestAPI(baseUrl, key, secret);
        WCObject wc = new WCObject(rest);
        int pageNum = 1;
        while (true) 
        {
            var page = pageNum.ToString();
            var getOrders = await wc.Order.GetAll(new Dictionary < string, string > () {
                    {
                        "page", page
                    }, {
                        "per_page", "100"
                    }
            });
            if (getOrders.Count < 100) 
            {
                ExtractWooData(getOrders);
                break;
            } 
            else 
            {
                ExtractWooData(getOrders);
                pageNum++;
            }
        }
        WriteToConsole(orders);
        WriteToFile(orders, outputPath);
    } 
    catch (Exception e) 
    {
        throw new Exception(e.Message);
    }
