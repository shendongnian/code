    internal static List<DashboardData> CloseWhereOpen(List<DashboardData> rawData, 
                                                   List<DashboardData> activitiesOpen)
    {
        var index = 0; 
        for (var i = rawData.Length -1; i >= 0; i--)
        {
            if (activitiesOpen.Select(ao=>ao.CanvasId == rawData[i].CanvasId).Count() > 0)      
            {
                rawData.RemoveAt(index);
            }
        }
    
        return rawData;
    }
