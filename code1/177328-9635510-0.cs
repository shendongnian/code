    private static void SetInterActWithDeskTop()
            {
                var service = new System.Management.ManagementObject(
                        String.Format("WIN32_Service.Name='{0}'", "YourServiceName"));
                try
                {
                    var paramList = new object[11];
                    paramList[5] = true;
                    service.InvokeMethod("Change", paramList);
                }
                finally
                {
                    service.Dispose();
                }
    
    
            }
