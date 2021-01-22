            PermissionSet ps = new PermissionSet(PermissionState.None);
            // ps.AddPermission(new System.Security.Permissions.*); // Add Whatever Permissions you want to grant here
            AppDomainSetup setup = new AppDomainSetup();
            Evidence ev = new Evidence();
            AppDomain sandbox = AppDomain.CreateDomain("Sandbox",
                ev,
                setup,
                ps);
            sandbox.ExecuteAssembly("ManagedAssembly.exe");
