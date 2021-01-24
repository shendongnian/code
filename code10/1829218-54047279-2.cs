    using System.Management;
    
    //....
    
    
          var domainName = "YourDomainName";
          var groupName = "Administrators";
          var wql = string.Format
          (
            @"select partcomponent from win32_groupuser where groupcomponent='Win32_Group.Domain=""{0}"",Name=""{1}""'",
            domainName,
            groupName
          );
          foreach ( var thing in new ManagementObjectSearcher( wql ).Get( ) )
          {
            foreach ( var property in thing.Properties )
            {
              //--> And then, if you want the account object...
              var path = new ManagementPath( property.Value as string );
              var account = new ManagementObject( path );
              foreach ( var acctProp in account.Properties )
              {
                Console.WriteLine( $"{acctProp.Name}={acctProp.Value}" );
              }
            }
          }
