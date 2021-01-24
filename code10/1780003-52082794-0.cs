    public static async Task PullInfo()
    {
       foreach (var item in SAPItems)
       {
            if(item.Latitude == null || item.Longitude == null)
            {
                 var point = await GetMapPoint(item.AddressLine1 + " " + item.FiveDigitZip);
                 item.MDM_Latitude = point.Latitude.ToString();
                 item.MDM_Longitude = point.Longitude.ToString();
            }                    
        }
        foreach(var item in SAPItems)
             Console.WriteLine(item.MDM_Latitude + " " + item.MDM_Longitude);
    }
    private static Task<MapPoint> GetMapPoint(string add)
    {
         var task = Task.Run(() => LocationService.GetLatLongFromAddress(add));
         return task;
    }
