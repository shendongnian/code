            DataContext context = null;
            object changeTracker = (from i in o1.GetInvocationList() where i.Target.GetType().FullName == "System.Data.Linq.ChangeTracker+StandardChangeTracker" select i.Target).FirstOrDefault();
            if (changeTracker != null) // DataCOntext tracks our changes through StandardChangeTracker
            {
                object services = Reflector.GetFieldValue(changeTracker, "services");
                context = (DataContext)Reflector.GetFieldValue(services, "context");
            }
