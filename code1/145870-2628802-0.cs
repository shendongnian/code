    public class Mediator
        {
            //instruct the robot to move.
            public delegate void Callback(string sender, string receiver, Message msg);
    
          
            Callback sendMessage;
    
            //Assign the callback method to the delegate	      
            public void SignOn(Callback moveMethod)
            {
                sendMessage += moveMethod; 
            }
    
            public void SendMessage(string sender, string receiver, string msg)
            {
                sendMessage(sender, receiver, msg);
            }
        }
    
    
    public class Controller : Asset
        {
            string readonly _name; 
            Mediator _mediator;	
            public Controller(Mediator m, string name)
            {
                  _name = name;
    	         _mediator = m;
    	        //assign the call back method
                _mediator.SignOn(Notification);
            }
    
            public void Notification(string sender, string receiver, string msg)
            {
                if (receiver == _name )
                {
                   Console.WriteLine("{0}: Message for {1} - {2}".FormateText(sender, 
                     receiver, msg)); //I have create extension method for FormatText.
                }
            }
    
            public void Mobilize(string receiver, string msg)
            {
                  _mediator.SendMessage(_name, receiver, msg);
            }
    
        }
    
    static void Main(string[] args)
    {
    
    	Mediator mediator;
    	mediator = new Mediator();
    
    	//accept name here...
    
    	Controller controller1 = new Controller(mediator, "name1");
    	Controller controller2 = new Controller(mediator, "name2");
    	controller1.Mobilize("name2","Hello");
    	controller1.Mobilize("name1", "How are you?");
    }
    
    output will be:
    
    name1: Message for name2 - Hello
    name2: Message for name1 - How are you?
