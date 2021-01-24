    foreach (var item1 in userids)  
    { 
       var BDName = item1.FullName;  
       var BDEmail = item1.Email;  
       var list = db.Purchases.Where(x => x.SubmittedBy == item1.Id).Select(x => x).ToList();
       // check
       if(list.Count > 0){
       //use rowspan to extend to multiple rows.   
         str.Append("<td><font face=Arial Narrow size=14px rowspan="+list.Count + ">" + BDName+ " </font></td>");  
         str.Append("<td><a href="+""+"><font face=Arial Narrow size= 14px rowspan="+list.Count ">" + BDEmail + "</font></a></td>"); 
         foreach (var item2 in list)
         {
          //the rest of the td
         }
       }
    }
