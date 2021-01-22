    public static int GetNumberOfDevicesForManagementGroup(Guid managementGroupId, bool firstTime, int counterValue)
      {
         int counter = 0;
         counter = counterValue;
         using (var ctx = new DeviceManagerEntities())
         {
            if (firstTime)
            {
               firstTime = false;
               counter = 0;
               GetNumberOfDevicesForManagementGroup(managementGroupId, firstTime);
            }
            else
            {
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
                     GetNumberOfDevicesForManagementGroup(group.ManagementGroupId, firstTime);
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
         }
         return counter;
      }
