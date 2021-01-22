    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.DirectoryServices;
    
    namespace DirectoryTest
    {
      class Program
      {
    
        private static Int32 counter = 1;
    
        static void Main(string[] args)
        {
          TestConnection();
        }
    
        private static void TestConnection()
        {
          String domainOne = "LDAP://DC=domain,DC=one";
          String domainOneName = "DOMAINONE";
          String domainOneUser = "onetest";
          String domainOnePass = "testingONE!";
    
          String domainTwo = "LDAP://DC=domain,DC=two";
          String domainTwoName = "DOMAINTWO";
          String domainTwoUser = "twotest";
          String domainTwoPass = "testingTWO!";
    
          String invalidDomain = "INVALIDDOMAIN";
    
          // 1) This works because it's the correct NT Account Name in the same domain:
          Connect(domainOne, domainOneName + "\\" + domainOneUser, domainOnePass);
    
          // 2) This works because username can be supplied without the domain part
          // (plain username = sAMAccountName):
          Connect(domainOne, domainOneUser, domainOnePass);
    
          // 3) This works because there's a fall back in DirectoryEntry to drop the domain part
          // and attempt connection using the plain username (sAMAccountName) in (in this case)
          // the forrest root domain:
          Connect(domainOne, invalidDomain + "\\" + domainOneUser, domainOnePass);
    
          // 4) This works because the forrest is searched for a domain matching domainTwoName:
          Connect(domainOne, domainTwoName + "\\" + domainTwoUser, domainTwoPass);
    
          // 5) This fails because domainTwoUser is not in the forrest root (domainOne)
          // and because no domain was specified other domains are not searched:
          Connect(domainOne, domainTwoUser, domainTwoPass);
    
          // 6) This fails as well because the fallback of dropping the domain name and using
          // the plain username fails (there's no domainTwoUser in domainOne):
          Connect(domainOne, invalidDomain + "\\" + domainTwoUser, domainTwoPass);
    
          // 7) This fails because there's no domainTwoUser in domainOneName:
          Connect(domainOne, domainOneName + "\\" + domainTwoUser, domainTwoPass);
    
          // 8) This works because there's a domainTwoUser in domainTwoName:
          Connect(domainTwo, domainTwoName + "\\" + domainTwoUser, domainTwoPass);
    
          // 9) This works because of the fallback to using plain username when connecting
          // to domainTwo with an invalid domain name but using domainTwoUser/Pass:
          Connect(domainTwo, invalidDomain + "\\" + domainTwoUser, domainTwoPass);
        }
    
        private static void Connect(String path, String username, String password)
        {
          Console.WriteLine(
            "{0}) Path: {1} User: {2} Pass: {3}",
            counter, path, username, password);
          DirectoryEntry de = new DirectoryEntry(path, username, password);
          try
          {
            de.RefreshCache();
            Console.WriteLine("{0} = {1}", username, "Autenticated");
          }
          catch (Exception ex)
          {
            Console.WriteLine("{0} ({1})", ex.Message, username);
          }
          Console.WriteLine();
          counter++;
        }
      }
    }
