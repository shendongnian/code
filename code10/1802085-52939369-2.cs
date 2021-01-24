    var computer = ComputersDbContext.Computers
                    .Where(a => a.ComputerId == computerId)
                    .First(t => t.TenantId == tenantId);
                    .Where(b => b.Computer_Win_Installed_Software.EntryTimestamp == EntryTimestamp);
                
