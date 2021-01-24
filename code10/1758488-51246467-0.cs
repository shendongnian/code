    public static void Display()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell UserDetailsPipe = PowerShell.Create();
            UserDetailsPipe.Commands.AddScript("Get-AzureADUser");
            Console.WriteLine("\n{0,-20}{1,-45}{2,-30}{3,-30}", "DisplayName", "UserPrincipalName", "MemberOf", "Licenses");
            Console.WriteLine("{0,-20}{1,-45}{2,-30}{3,-30}", "-----------", "-----------------", "--------", "--------");
           
            var Users = UserDetailsPipe.Invoke();
            foreach (var info in Users)
            {
                ArrayList Groups = new ArrayList();   // to hold memberOf
                ArrayList Licenses = new ArrayList(); // to hold of licenses
                string UserPrincipalName = info.Members["UserPrincipalName"].Value.ToString();
                string DisplayName = info.Members["DisplayName"].Value.ToString();
                //Getting MemberOf
                PowerShell newPipe = PowerShell.Create();
                newPipe.Runspace = runspace;
                newPipe.AddScript("Get-AzureADUserMembership -ObjectId '" + UserPrincipalName + "' ; $license = Get-AzureADUserLicenseDetail -ObjectId '" + UserPrincipalName + "' | select ServicePlans ;$license.ServicePlans");
                var AllInfo= newPipe.Invoke();
                try
                {
                  
                    foreach (var licensenames in AllInfo)
                    {
                        if (licensenames.Members["DisplayName"]!=null)
                            Groups.Add(licensenames.Members["DisplayName"].Value.ToString());
                        if (licensenames.Members["ServicePlanName"] != null)
                            Licenses.Add(licensenames.Members["ServicePlanName"].Value.ToString());
                    }
                }
                catch (Exception)
                {
                }
				
                //Displaying UsersInfo
                for (int groupIndex = 0, licenseIndex = 0; groupIndex < Groups.Count || licenseIndex < Licenses.Count; groupIndex++, licenseIndex++)
                {
                    if (groupIndex == 0 && licenseIndex == 0)
                    {
                        Console.Write("{0,-20}{1,-45}", DisplayName, UserPrincipalName);
                    }
                    else
                    {
                        Console.Write("{0,-20}{1,-45}", " ", " ");
                    }
                    if (groupIndex < Groups.Count)
                    {
                        Console.Write("{0,-30}", Groups[groupIndex]);
                    }
                    else
                    {
                        Console.Write("{0,-30}", " ");
                    }
                    if (licenseIndex < Licenses.Count)
                    {
                        Console.Write("{0,-30}", Licenses[licenseIndex]);
                    }
                    else
                    {
                        Console.Write("{0,-30}", " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
