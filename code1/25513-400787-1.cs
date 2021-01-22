    namespace ADAM_Examples
    {
        class CreateOU
        {
            /// <summary>
            /// Create AD LDS Organizational Unit.
            /// </summary>
            [STAThread]
            static void Main()
            {
                DirectoryEntry objADAM;  // Binding object.
                DirectoryEntry objOU;    // Organizational unit.
                string strDescription;   // Description of OU.
                string strOU;            // Organiztional unit.
                string strPath;          // Binding path.
            // Construct the binding string.
            strPath = "LDAP://localhost:389/O=Fabrikam,C=US";
            Console.WriteLine("Bind to: {0}", strPath);
            // Get AD LDS object.
            try
            {
                objADAM = new DirectoryEntry(strPath);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Bind failed.");
                Console.WriteLine("         {0}", e.Message);
                return;
            }
            // Specify Organizational Unit.
            strOU = "OU=TestOU";
            strDescription = "AD LDS Test Organizational Unit";
            Console.WriteLine("Create:  {0}", strOU);
            // Create Organizational Unit.
            try
            {
                objOU = objADAM.Children.Add(strOU,
                    "OrganizationalUnit");
                objOU.Properties["description"].Add(strDescription);
                objOU.CommitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Create failed.");
                Console.WriteLine("         {0}", e.Message);
                return;
            }
            // Output Organizational Unit attributes.
            Console.WriteLine("Success: Create succeeded.");
            Console.WriteLine("Name:    {0}", objOU.Name);
            Console.WriteLine("         {0}",
                objOU.Properties["description"].Value);
            return;
        }
    }
    }
