    // 1. First Your have to put Notification into a variable.
    var notification = Null; // For Example Notification Parameter has null value
    
    // 2. You Have to Write a Queries based on your requirements.
    string queryWhenNotificationIsNull = "SELECT ...."; // This Query doesn't include AND Condition.
    
    string queryWhenNotificationIsNotNull = "SELECT ... "; // This Query include AND Condition.
    
    // 3. You have to check that the Notification Parameter is Null or Not ?
    if(string.IsNullOrEmpty(Notification))
       // call QueryWhenNotificationIsNull ....
    else
       // call QueryWhenNotificationIsNotNull ....
