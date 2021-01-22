    using System;
    using System.DirectoryServices.Protocols;
    using System.Net;
    namespace ProtocolTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    LdapConnection connection = new LdapConnection("ldap.fabrikam.com");
                    NetworkCredential credential = new NetworkCredential("user", "password");
                    connection.Credential = credential;
                    connection.Bind();
                    Console.WriteLine("logged in");
                }
                catch (LdapException lexc)
                {
                    String error = lexc.ServerErrorMessage;
                    Console.WriteLine(lexc);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }
    }
