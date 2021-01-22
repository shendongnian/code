        public void changeServiceStartMode(string hostname, string serviceName, string startMode)
        {
            try
            {
                ManagementObject classInstance =
                            new ManagementObject(@"\\" + hostname + @"\root\cimv2",
                            "Win32_Service.Name='" + serviceName + "'",
                            null);
                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    classInstance.GetMethodParameters("ChangeStartMode");
                // Add the input parameters.
                inParams["StartMode"] = startMode;
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("ChangeStartMode", inParams, null);
                // List outParams
                //Console.WriteLine("Out parameters:");
                //richTextBox1.AppendText(DateTime.Now.ToString() + ": ReturnValue: " + outParams["ReturnValue"]);
            }
            catch (ManagementException err)
            {
                //richTextBox1.AppendText(DateTime.Now.ToString() + ": An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }
