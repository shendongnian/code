    var btns = pnContacts.Controls.OfType<UserButton>();
    for(var i = 0; i < btns.Count; i++)
    {
       //I guess that you pnContacts.Controls.OfType<UserButton> - 
       //it's List, case call Count method to get List length
       if (btns[i].DisplayName == name)
       {
          btns.Remove(btns[i]);
       }
       else
       {
          btns[i].DisplayName = i.ToString();
       }
    }
