    // Inserts / Updates Zone; returns the ID of the Saved zone
    public async Task<int> SaveZoneAsync(Zone zone)
    {
        if (zone.ID == 0)
        {
            int zoneId = await database.InsertAsync(zone);
            return zoneId;
        }
        else
        {
            await database.UpdateAsync(zone);
            return zone.Id;
        }
    }
    public static int AddZoneToDB(Zone zone)
    {
        Task<int> taskSaveZone = Task.Run( () => SaveZoneAsync(zone);
        taskSaveZone.Wait();
        int zoneId = taskSaveZone.Result;
        return zoneId;
        // TODO: consider putting this all in one statement
    }
