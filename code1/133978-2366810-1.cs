    public static void perforce_sync()
        {
          
            string computer_name = @"server_name";
            ManagementScope scope = new ManagementScope("\\\\" + computer_name + "\\root\\cimv2");
            scope.Connect();
            ObjectGetOptions object_get_options = new ObjectGetOptions();
            ManagementPath management_path = new ManagementPath("Win32_Process");
            ManagementClass process_class = new ManagementClass(scope, management_path, object_get_options);
            ManagementBaseObject inparams = process_class.GetMethodParameters("create");
            inparams["CommandLine"] = @"p4 sync -f //release/...";
            ManagementBaseObject outparams = process_class.InvokeMethod("Create", inparams, null);
            Console.WriteLine("Creation of the process returned: " + outparams["returnValue"]);
            Console.WriteLine("Process ID: " + outparams["processId"]);
           
        }
