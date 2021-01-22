     LinkButton link= new LinkButton();
     link.Command +=new CommandEventHandler(LinkButton1_Command);
     protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(300);
            if (e.CommandName == "link")
            {
               //////////
            }
        }
        catch
        {
        }
    }
