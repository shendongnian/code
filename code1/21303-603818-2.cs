    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.DirectoryServices.AccountManagement;
    class WindowsCred
    {
        private const string SPLIT_1 = "\\";
        public static bool ValidateW(string UserName, string Password)
        {
            bool valid = false;
            string Domain = "";
            if (UserName.IndexOf("\\") != -1)
            {
                string[] arrT = UserName.Split(SPLIT_1[0]);
                Domain = arrT[0];
                UserName = arrT[1];
            }
            if (Domain.Length == 0)
            {
                Domain = System.Environment.MachineName;
            }
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, Domain)) 
            {
                valid = context.ValidateCredentials(UserName, Password);
            }
            
            return valid;
        }
    }
