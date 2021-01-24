     public static List<UserPresave> GetAllUserPresavesByPresaveIDs(List<Presave> ids)
     {
         var hs = new HashSet<int>(ids.Select(x=>x.PresaveID));
         using (var Context = GetContext())
         {
             return Context.UserPresaves.Where(x => hs.Contains(x.PresaveID)).ToList();
         }
     }
