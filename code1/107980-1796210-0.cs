    var rooms = from roomBinding in DALManager.Context.RoomBindings
                            group roomBinding by new 
                            { 
                               Id = roomBinding.R_ID, 
                               Name = roomBinding.r_name
                            }
                            into g
                            select new 
                            { 
                               Id = g.Key.Id,
                               Name = g.Key.Name,
                               Count = g.Count()  
                            };
