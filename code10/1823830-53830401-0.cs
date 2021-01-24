    public string GetHrEmail() 
    {
    //get users with roleid= 17
    var queryHrExeEmail = 
    (from cust in db.EMS_USER_MASTER
    where cust.ROLE_ID == 17
    select cust);
    
     //selecting emails
    var emailList=queryHrExeEmail.Select(e=>e.EMAIL);
    
    //join selected emails with ,
    return string.Join(",", emailList);
    }
