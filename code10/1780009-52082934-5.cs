    public static void PullInfo()
    {
        // Create tasks to update items with latitude and longitude
        var tasks
            = SAPItems.Where(item => item.Latitude == null || item.Longitude == null)
                .Select(item =>
                    GetMapPoint(item.AddressLine1 + " " + item.FiveDigitZip)
                        .ContinueWith(point => {
                            item.MDM_Latitude = point.Latitude.ToString();
                            item.MDM_Longitude = point.Longitude.ToString();
                        }));
        // Wait for tasks completion (it will block the current thread)
        Task.WaitAll(tasks.ToArray());
        // Iterate to append Lat and Long
        foreach(var item in SAPItems)
            Console.WriteLine(item.MDM_Latitude + " " + item.MDM_Longitude);
    }
    private static Task<MapPoint> GetMapPoint(string add)
    {
         return Task.Run(() => LocationService.GetLatLongFromAddress(add));
    }
