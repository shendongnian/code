    db.CallQueues.Add(cq);
    db.SaveChanges();
 
    string queryStringParameter = "?cq_id=" + cq.id;
    string callbackUrl = TwilioCallBotController.SMSCallBackURL + queryStringParameter;
    var message = MessageResource.Create
    (
        [...]
        statusCallback: new Uri(callbackUrl)
    );
 
