    Action<object> d = delegate(object val)
    {
        System.Threading.Thread.Sleep(1000);  // waits a little
        Session["rubbish"] = DateTime.Now;
    };
    d.BeginInvoke(null, null, null);
    System.Threading.Thread.Sleep(5000);      // waits a lot
    object stuff = Session["rubbish"];
    if( stuff == null ) stuff = "not there";
    divStuff.InnerHtml = Convert.ToString(stuff);
