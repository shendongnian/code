    var a = new Activity();
    a.Conversation = context.Activity.Conversation;
    a.Recipient = context.Activity.Recipient;
    a.From = context.Activity.From;
    a.Id = context.Activity.Id;
    ...    //set whatever else you need set
    a.Text = "Whatever you need the text to be";
    
    //send or process the activity do what it is you are trying to accomplish
