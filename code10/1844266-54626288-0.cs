    bool isNude = false;
    var SearchTask = Task.Run(async () =>
    {
    	foreach (var file in await GetFileListAsync(GlobalData.Config.DataPath))
    	{
    		isNude = false;
    		if (!ct.IsCancellationRequested)
    		{
    			await Dispatcher.InvokeAsync(() =>
    			{
    				if (ButtonNude.IsChecked == true)
    				{
    					foreach (var itemx in nudeData)
    					{
    						if (itemx.Equals(Path.GetFileNameWithoutExtension(file.FullName)))
    						{
    							isNude = true;
    							break;
    						}
    					}
    				}
    				if (isNude)
    					return; // continue -> return
    
    	            // other code
    				}, DispatcherPriority.Background);
    				
                    // <--- code continues here after return
    			}
    	}
    }, ct);
