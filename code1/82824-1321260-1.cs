    public static class DCExtensions
    {
        internal static void MakeDirty(this System.Data.Linq.DataContext dc, object someEntity)
        {
            //get dc type
            Type dcType = dc.GetType();
            while (dcType != typeof(System.Data.Linq.DataContext))
            {
                dcType = dcType.BaseType;
            }  
              
            //get hold of the CommonDataServices thing in the DC
            System.Reflection.FieldInfo commonDataServicesField 
                = dcType.GetField("services", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            object commonDataServices = commonDataServicesField.GetValue(dc);
            Type commonDataServicesType = commonDataServices.GetType();  
      
            //get hold of the change tracker
            System.Reflection.PropertyInfo changeTrackerProperty 
                = commonDataServicesType.GetProperty("ChangeTracker", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            object changeTracker = changeTrackerProperty.GetValue(commonDataServices, null);
            Type changeTrackerType = changeTracker.GetType();  
      
            //get the tracked object method
            System.Reflection.MethodInfo getTrackedObjectMethod
                = changeTrackerType.GetMethod("GetTrackedObject", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            object trackedObject = getTrackedObjectMethod.Invoke(changeTracker, new object[] { someEntity } );  
      
            //get the ConvertToModified method
            Type trackedObjectType = trackedObject.GetType();
            System.Reflection.MethodInfo convertToModifiedMethod
                = trackedObjectType.GetMethod("ConvertToModified", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);  
      
            //call the convert to modified method
            convertToModifiedMethod.Invoke(trackedObject, null);
        }
    }
