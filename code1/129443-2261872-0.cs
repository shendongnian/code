    public static int GetNumberOfDevicesForManagementGroup(Guid managementGroupId)
    {
         // *** Initialization
         int counter = 0;
         using (var ctx = new DeviceManagerEntities())
         {
           // *** No first time special case
           var groups = ctx.ManagementGroups
              .Where(x => x.ParentId == managementGroupId)
              .ToList();
           if (groups.Count != 0)
           {
              foreach (ManagementGroups group in groups)
              {
                 var devices = ctx.Devices
                    .Where(x => x.ManagementGroups.ManagementGroupId == group.ManagementGroupId)
                    .ToList();
                 foreach (Devices device in devices)
                 {
                    counter++;
                 }
                 // *** Sum of recursive result
                 counter += GetNumberOfDevicesForManagementGroup(group.ManagementGroupId, firstTime);
              }
           }
           else
           {
              var devices = ctx.Devices
                    .Where(x => x.ManagementGroups.ManagementGroupId == managementGroupId)
                    .ToList();
              foreach (Devices device in devices)
              {
                 counter++;
              }
           }
         }
         return counter;
      }
