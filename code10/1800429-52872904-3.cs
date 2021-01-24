    var query = buildingObjects.GroupBy(x => new { x.ObjectId, x.GUID })
                               .Where(g => g.Count() > 1)
                               .Select(group => new LogServiceModel() 
                                { 
                                    LogType = LogTypes.Warning, 
                                    Parameters = group.Key.GUID, 
                                    LogTitle = $"You have used two different classifications on a same Buildingobject, Id: {group.Key.ObjectId}." 
                                });
