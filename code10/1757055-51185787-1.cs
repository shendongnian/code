    // now getting all areas
    List<Area> areas= new List<Area>();
    foreach (Link_Table link in links)
    {
        // ERROR
        areas.Add(db.Area.Where(item => item.ID == link.areaID).First());
    }
