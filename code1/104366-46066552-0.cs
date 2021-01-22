            // get the ServiceHostingEnvironmentSection by calling an internal static method
            var section = (ServiceHostingEnvironmentSection)typeof(ServiceHostingEnvironmentSection).GetMethod("UnsafeGetSection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Invoke(null, null);
            // set the read-only flag to false so values can be updated
            typeof(ServiceHostingEnvironmentSection).BaseType.BaseType.GetField("_bReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(section, false);
            // set the AspNetCompatibilityEnabled value
            section.AspNetCompatibilityEnabled = true;
            // now one can add a Service Route
            routes.Add(new ServiceRoute("MyRoutePrefix", new ServiceHostFactory(), typeof(MyService)));
