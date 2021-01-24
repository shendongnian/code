    ServiceBackupList.Where(x=>!string.IsNullOrEmpty(x.SPPServer))
                    .Select(x =>
                         new SelectListItem()
                         {
                           Value = x.ServerInstanceId.ToString(),
                           Text = x.SPPServerName,
                           Group = group1
                         })
                    .Concat(ServiceBackupList
                    .Where(x=>!string.IsNullOrEmpty(x.SPPServer))
                    .Select(x =>
                         new SelectListItem()
                         {
                           Value = x.NodeGuid.ToString(),
                           Text = x.SPServerName,
                           Group = group2
                         })).ToList();
                 
