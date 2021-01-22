    var query2 = (
        from users in Repo.T_User
        from mappings in Repo.T_User_Group
             .Where(mapping => mapping.USRGRP_USR == users.USR_ID)
             .DefaultIfEmpty() // <== makes join left join
        from groups in Repo.T_Group
             .Where(gruppe => gruppe.GRP_ID == mappings.USRGRP_GRP)
             .DefaultIfEmpty() // <== makes join left join
        // where users.USR_Name.Contains(keyword)
        // || mappings.USRGRP_USR.Equals(666)  
        // || mappings.USRGRP_USR == 666 
        // || groups.Name.Contains(keyword)
    
        select new
        {
             UserId = users.USR_ID
            ,UserName = users.USR_User
            ,UserGroupId = mappings.USRGRP_GRP
            ,GroupName = groups.Name
        }
    
        );
    
    
    var xy = (query2).ToList();
