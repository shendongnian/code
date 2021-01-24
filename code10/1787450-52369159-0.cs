    List<string> changeOne = new List<string>
    for (int i=0;i<msg.Count();i++)
    {
       if (msg[i] == "A")
       {
         changeOne.AddRange( new [] {"\\","p","\\",";" });
       }
       else
       {
              changeOne.Add(msg[i]);
       }
    }
