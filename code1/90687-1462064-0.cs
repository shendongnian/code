        public static void UpdateSecurity(string destination, DirectorySecurity templateSecurity)
        {
            DirectorySecurity dSecurity = Directory.GetAccessControl(destination);
            string sddl = templateSecurity.GetSecurityDescriptorSddlForm(AccessControlSections.Access);
            try
            {
                // TOTALLY REPLACE The existing access rights with the new ones.
                dSecurity.SetSecurityDescriptorSddlForm(sddl, AccessControlSections.Access);
                // Disable inheritance for this directory.
                dSecurity.SetAccessRuleProtection(true, true);
                // Apply these changes.
                Directory.SetAccessControl(destination, dSecurity);
            }
            catch (Exception ex)
            {
                // Note the error on the console... we can formally log it later.
                Console.WriteLine(pth1 + " : " + ex.Message);
            }
            // Do some other settings stuff here...
        }
Note the AccessControlSections.Access flags on the SDDL methods. That was the magic key to make it all work.
