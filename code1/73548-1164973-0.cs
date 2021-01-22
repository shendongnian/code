    using System.Linq;
    ...
        var ccList = from c in ds.Tables[2].AsEnumerable()
                     select c.Field<string>("Country"); 
        var bannedCCList = from c in ds.Tables[1].AsEnumerable()
                           select c.Field<string>("Country");
        var exceptBanned = ccList.Except(bannedCCList);
