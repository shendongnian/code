    var relatedActivities = new List<TActivity>();
    bool found = false;
    foreach (var item in activities.OrderBy(a => a.ActivityDate))
    {
        int count = relatedActivities.Count;
        if ((count > 0) && (relatedActivities[count - 1].ActivityDate.Date.AddDays(1) != item.ActivityDate.Date))
        {
            if (found)
                break;
            relatedActivities.Clear();
        }
        relatedActivities.Add(item);
        if (item.ID == activity.ID)
            found = true;
    }
    if (!found)
        relatedActivities.Clear();
