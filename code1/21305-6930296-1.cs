    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security;
    using System.DirectoryServices.AccountManagement;
    public struct Credentials
    {
        public string Username;
        public string Password;
    }
    public class Domain_Authentication
    {
        public Credentials Credentials;
        public string Domain;
        public Domain_Authentication(string Username, string Password, string SDomain)
        {
            Credentials.Username = Username;
            Credentials.Password = Password;
            Domain = SDomain;
        }
        public bool IsValid()
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain))
            {
                // validate the credentials
                return pc.ValidateCredentials(Credentials.Username, Credentials.Password);
            }
        }
    }
