    PropertyInfo p = typeof(HttpRuntime).GetProperty("FileChangesMonitor", 
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static); 
     
                object o = p.GetValue(null, null); 
     
                FieldInfo f = o.GetType().GetField("_dirMonSubdirs", 
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase); 
     
                object monitor = f.GetValue(o); 
     
                MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", 
                    BindingFlags.Instance | BindingFlags.NonPublic); 
                 
                m.Invoke(monitor, new object[] { }); 
