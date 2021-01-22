    // but in this case lazy loading is not supported
       
    
        public AppEmployeeDataContext() : 
        				base(global::LinqLibrary.Properties.Settings.Default.AppConnect3DBConnectionString, mappingSource)
        		{
                    this.ObjectTrackingEnabled = false;
        			OnCreated();
        		}
