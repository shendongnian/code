        bool SetServiceDependencies(string serviceName, string[] dependencies)
        {
            try
            {
                string objPath = string.Format("Win32_Service.Name='{0}'", serviceName);
                //Uses lazy initialization
                ManagementObject mmo = new ManagementObject(new ManagementPath(objPath));
                //Get properties to check if object is valid, if not then it throws a ManagementException
                PropertyDataCollection pc = mmo.Properties;
            }
            catch (ManagementException me)
            {   //Handle errors
                if (me.ErrorCode == ManagementStatus.NotFound) {
                    //Service not found
                }
                return false;
            }
            try
            {   
                object[] wmiParams = new object[11];    //parameters for Win32_Service mmo object Change-parameters
                wmiParams[10] = dependencies;
                //Should we remove dependencies, use array containging 1 empty string
                if (dependencies == null || dependencies.Length == 0)
                {
                    wmiParams[10] = new string[] { "" };
                }
                //Change dependencies
                string returnStatus = mWmiService.InvokeMethod("Change", wmiParams).ToString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
