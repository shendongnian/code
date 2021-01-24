    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic;
    using System.Management;
    using System.Windows.Forms;
    
    namespace WMISample
    {
        public class CallWMIMethod
        {
            public new static int Main()
            {
                try
                {
                    ManagementObject classInstance = new ManagementObject(@"root\DEFAULT", "SystemRestore.ReplaceKeyPropery='ReplaceKeyPropertyValue'", null);
    
                    // Obtain [in] parameters for the method
                    ManagementBaseObject inParams = classInstance.GetMethodParameters("CreateRestorePoint");
    
                    // Add the input parameters.
    
                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = classInstance.InvokeMethod("CreateRestorePoint", inParams, null);
    
                    // List outParams
                    Console.WriteLine("Out parameters:");
                    Console.WriteLine("ReturnValue: {0}", outParams("ReturnValue"));
                }
                catch (ManagementException err)
                {
                    MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
                }
            }
        }
    }
