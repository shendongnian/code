    private void MyManagerJob()
        {
            bool moreToDo = true;
            while (moreToDo)
            {
                if (contentManagerState)
                {
                    Thread.Sleep(1000);
                    //var s = sequences.
                    #region Start tasks to download content data
                    // Each task should check if there is a file. If there is not  a file it should be downloaded. 
                    List<ContentItem> contentItems = (List<ContentItem>)App.Current.Properties["ContentItems"];
                    foreach (var ci in contentItems)
                    {
                        if (ci.IsDownloadable)
                        {
                            // Delete finished tasks
                            var finishedTasks = (from c in contentManagerWorkArea where c.Value.TaskResult.Result == true select c).AsParallel();
                            foreach (var finishedTask in finishedTasks)
                            {
                                ContentManagerTask ctm;
                                contentManagerWorkArea.TryRemove(finishedTask.Key, out ctm);
                                CustomLogger.WriteNormalLog(string.Format("Content Manager: Finished Task has been deleted. Time: {0}; ID: {1}; File: {2}; URL: {3} ", DateTime.Now.ToString(), ctm.TaskResult.ContentItem.ID, ctm.TaskResult.ContentItem.FileName, ctm.TaskResult.ContentItem.URL));
 
                                ctm = null;
                            }
                            // Add new task
                            var unfinishedTasks = (from c in contentManagerWorkArea where c.Value.TaskResult.Result == false select c).AsParallel();
                            if (unfinishedTasks.Count() == 0) // Area is empty we have to add the first task
                            {
                                DownloadResult dr = new DownloadResult();
                                dr.ContentItem = ci;
                                ContentManagerTask contentManagerTask = new ContentManagerTask(dr);
                                contentManagerWorkArea.TryAdd(ci.ID, contentManagerTask);
                                CustomLogger.WriteNormalLog(string.Format("Content Manager: New Task has been added. Time: {0}; ID: {1}; File: {2}; URL: {3} ", DateTime.Now.ToString(), ci.ID, ci.FileName, ci.URL));
                            }
                            else // Area is not empty and we have to check if some of the tasks are the same we have to insert in
                            {
                                foreach (var unfinishedTask in unfinishedTasks)
                                {
                                    if (!unfinishedTask.Value.TaskResult.ContentItem.ID.Equals(ci.ID))
                                    {
                                        DownloadResult dr = new DownloadResult();
                                        dr.ContentItem = ci;
                                        ContentManagerTask contentManagerTask = new ContentManagerTask(dr);
                                        contentManagerWorkArea.TryAdd(ci.ID, contentManagerTask);
                                        CustomLogger.WriteNormalLog(string.Format("Content Manager: New Task has been added. Time: {0}; ID: {1}; File: {2}; URL: {3} ", DateTime.Now.ToString(), ci.ID, ci.FileName, ci.URL));
                                    }
                                }
                            }
                        }
                    }
                   
                }
            }
        }
