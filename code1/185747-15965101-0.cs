    public static void CreateSharedFolder(string FolderPath, string ShareName, string Description)
    {
        try
        {
            // Create a ManagementClass object
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            // Create ManagementBaseObjects for in and out parameters
            ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
            ManagementBaseObject outParams;
            // Set the input parameters
            inParams["Description"] = Description;
            inParams["Name"] = ShareName;
            inParams["Path"] = FolderPath;
            inParams["Type"] = 0x0; // Disk Drive
            //Another Type:
            // DISK_DRIVE = 0x0
            // PRINT_QUEUE = 0x1
            // DEVICE = 0x2
            // IPC = 0x3
            // DISK_DRIVE_ADMIN = 0x80000000
            // PRINT_QUEUE_ADMIN = 0x80000001
            // DEVICE_ADMIN = 0x80000002
            // IPC_ADMIN = 0x8000003
            //inParams["MaximumAllowed"] = 2;
            inParams["Password"] = null;
            NTAccount everyoneAccount = new NTAccount(null, "EVERYONE");
            SecurityIdentifier sid = (SecurityIdentifier)everyoneAccount.Translate(typeof(SecurityIdentifier));
            byte[] sidArray = new byte[sid.BinaryLength];
            sid.GetBinaryForm(sidArray, 0);
            ManagementObject everyone = new ManagementClass("Win32_Trustee");
            everyone["Domain"] = null;
            everyone["Name"] = "EVERYONE";
            everyone["SID"] = sidArray;
            ManagementObject dacl = new ManagementClass("Win32_Ace");
            dacl["AccessMask"] = 2032127;
            dacl["AceFlags"] = 3;
            dacl["AceType"] = 0;
            dacl["Trustee"] = everyone; 
            ManagementObject securityDescriptor = new ManagementClass("Win32_SecurityDescriptor");
            securityDescriptor["ControlFlags"] = 4; //SE_DACL_PRESENT 
            securityDescriptor["DACL"] = new object[] { dacl };
            inParams["Access"] = securityDescriptor;
            // Invoke the "create" method on the ManagementClass object
            outParams = managementClass.InvokeMethod("Create", inParams, null);
            // Check to see if the method invocation was successful
            var result = (uint)(outParams.Properties["ReturnValue"].Value);
            switch (result)
            {
                case 0:
                    Console.WriteLine("Folder successfuly shared.");
                    break;
                case 2:
                    Console.WriteLine("Access Denied");
                    break;
                case 8:
                    Console.WriteLine("Unknown Failure");
                    break;
                case 9:
                    Console.WriteLine("Invalid Name");
                    break;
                case 10:
                    Console.WriteLine("Invalid Level");
                    break;
                case 21:
                    Console.WriteLine("Invalid Parameter");
                    break;
                case 22:
                    Console.WriteLine("Duplicate Share");
                    break;
                case 23:
                    Console.WriteLine("Redirected Path");
                    break;
                case 24:
                    Console.WriteLine("Unknown Device or Directory");
                    break;
                case 25:
                    Console.WriteLine("Net Name Not Found");
                    break;
                default:
                    Console.WriteLine("Folder cannot be shared.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }
    }
    internal static void RemoveSharedFolder(string ShareName)
    {
        try
        {
            // Create a ManagementClass object
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            ManagementObjectCollection shares = managementClass.GetInstances();
            foreach (ManagementObject share in shares)
            {
                if (Convert.ToString(share["Name"]).Equals(ShareName))
                {
                    var result = share.InvokeMethod("Delete", new object[] { });
                    // Check to see if the method invocation was successful
                    if (Convert.ToInt32(result) != 0)
                    {
                        Console.WriteLine("Unable to unshare directory.");
                    }
                    else
                    {
                        Console.WriteLine("Folder successfuly unshared.");
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }
    }
