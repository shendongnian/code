    public partial class App : Application
    {
    		string fileName = "App.txt";
    		
    		private void Application_Startup(object sender, StartupEventArgs e)
    		{
    			// read Iso Storage file
                            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
    			try
    			{
    				using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Open, storage))
    				using (StreamReader reader = new StreamReader(stream))
    				{
    					while (!reader.EndOfStream)
    					{
    						// populate Application Properties
                                                    string[] keyValue = reader.ReadLine().Split(new char[] { ',' });
    						this.Properties[keyValue[0]] = keyValue[1];
    					}
    				}
    			}
    			catch (FileNotFoundException)
    			{
    				// Set default values.  You would probably want to read these values from a config file
                                    this.Properties["LocalServiceAddress"] = "http://localhost/myservice";
    				this.Properties["TranscodeServer"] = "http://localhost";
    				
    			}
    		}
    
    		private void Application_Exit(object sender, ExitEventArgs e)
    		{
    			// Persist application-scope property to isolated storage
    			IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
    			using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Create, storage))			
    			using (StreamWriter writer = new StreamWriter(stream))
    			{
    				// Persist each application-scope property individually
    				foreach (string key in this.Properties.Keys)
    				{
    					writer.WriteLine("{0},{1}", key, this.Properties[key]);
    				}
    			}
    		}
    	}
