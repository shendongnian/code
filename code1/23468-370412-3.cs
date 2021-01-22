    public class EventBroadcaster {
       //use your singleton pattern of choice. This is not what I would reocmmend but its short
       private static EventBroadcaster Instance=new EventBroadcaster;
    
       public void RegisterForEvent(string key,Delegate del)
       {
        //Store the delegate in a dictionary<string,del>
       //You can also use multicast delegates so if your settings object changes notify all people who need it
        }
    
       public void FireEvent(string key,EventArgs e)
       {
       //Get the item and execute it. 
       }
    }
