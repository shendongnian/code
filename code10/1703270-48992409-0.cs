    ...
    ...
    ...
     if (fbApplicationDifferences.ExistOnlyInSource.Any())
                {
                    // items to remove from the table, as these apps are now assigned to a different project.
                    var allAppsToRemove = fbApplicationDifferences.ExistOnlyInSource.Select(x => new inf_DMS_FBApplicationProjectMapping
                                                                                                 {
                                                                                                     ApplicationId = x.appId,
                                                                                                     ProjectID = x.projectId,
                                                                                                     MapId = Db.inf_DMS_FBApplicationProjectMapping.Single(m => m.ApplicationId == x.appId).MapId
                                                                                                 }).ToList();
    
                    foreach (var app in allAppsToRemove)
                    {
                        var item = Db.inf_DMS_FBApplicationProjectMapping.Find(app.MapId);
                        Db.Entry(item).State = EntityState.Deleted;
                    }
    
                    //Db.inf_DMS_FBApplicationProjectMapping.RemoveRange(allAppsToRemove); <-- these items are already "flagged for deletion" with .State property change a few lines above. 
                }
