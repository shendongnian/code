        //This code is actually taken almost literally from the Microsoft example 
        // given here: https://docs.microsoft.com/en-us/uwp/api/windows.storage.search.queryoptions
       private async Task GetFilesInFolder(StorageFolder folder)
        {
                List<string> fileTypeFilter = new List<string>();
                fileTypeFilter.Add(".png");
                fileTypeFilter.Add(".jpg");
                fileTypeFilter.Add(".jpeg");
                fileTypeFilter.Add(".tiff");
                fileTypeFilter.Add(".nef");
                fileTypeFilter.Add(".cr2");
                fileTypeFilter.Add(".bmp");
                QueryOptions queryOptions = new QueryOptions(Windows.Storage.Search.CommonFileQuery.OrderByName, fileTypeFilter);
                queryOptions.FolderDepth = FolderDepth.Deep;
                queryOptions.IndexerOption = IndexerOption.UseIndexerWhenAvailable;
                StorageFileQueryResult queryResult = folder.CreateFileQueryWithOptions(queryOptions);
                var files = await queryResult.GetFilesAsync();
                if (files.Count == 0)
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { cmdbar.Content = "Nothing found!" ; });
                }
                else
                {
                    // Add each file to the list of files (this takes 2 seconds)
                    foreach (StorageFile file in files)
                    {
                        _allFiles.Add(file as StorageFile);
                        numfiles = numfiles + 1;
                        //Display the file count so I can track where it's at...
                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { cmdbar.Content = "Number of slides:" + numfiles.ToString(); });
                    }
                }
        }
