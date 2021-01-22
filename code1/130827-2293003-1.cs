    bool ObjectWasUnlocked(object x)
    {
       if(System.Threading.Monitor.TryEnter(x))
       {
           System.Threading.Monitor.Exit(x);
           return true;
       }
       else
       {
           return false;
       }
    }
