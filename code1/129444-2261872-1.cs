    public static int GetNumberOfDevicesForManagementGroup(Guid managementGroupId)
    {
         // *** Initialization
         int counter = 0;
         using (/* ... */)
         {
           // *** No first time special case
           var groups = // ...
           if (groups.Count != 0)
           {
              foreach (ManagementGroups group in groups)
              {
                 // *** No need to call ToList() to count
                 counter += ctx.Devices
                    .Count(x => x.ManagementGroups.ManagementGroupId == group.ManagementGroupId)
                 // *** Add recursive result
                 counter += GetNumberOfDevicesForManagementGroup(group.ManagementGroupId);
              }
           }
           else
           {
              // *** Use LINQ to count
              counter = devices.Count(x => x.ManagementGroups.ManagementGroupId == group.ManagementGroupId);
           }
         }
         return counter;
      }
