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
          foreach ( var thing in new ManagementObjectSearcher( wql).Get())
          {
            foreach ( var property in thing.Properties )
            {
              Console.WriteLine( property.Value );
            }
          }
