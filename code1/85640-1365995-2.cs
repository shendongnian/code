    enum MessageType
    {
        Update,
        Delete,
        Destroy
    }
   
    MessageType t = ...;
   
    switch(t){
       case MessageType.Update:
           DoUpdate();
       }
    }
   
