    var db = new MessageDataContext();
    db.Log = Console.Out;
    Message m = new Message();
    m.Text = "Hello, world!";
    db.Messages.InsertOnSubmit(m);
    db.SubmitChanges();
