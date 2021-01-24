     public void OnNext()
               {
            var list = list.Where(ro => ro.roleID = 2 && ro.roleID = 3)
                           .Select(ro => new CacheObject
                               {
                                Hr_Email = ro.EMAIL,
                                BuHead_Email=ro.EMAIL
                               }
               )
               }
