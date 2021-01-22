	using System;
	namespace test{
		class MyTestApp{
			//The Event Handler declaration
			public delegate void EventHandler();
			
			//The Event declaration
			public event EventHandler MyHandler;
			
			//The method to call
			public void Hello(){
				Console.WriteLine("Hello World of events!");
			}
			
			public static void Main(){
				MyTestApp TestApp = new MyTestApp();
				
				//Assign the method to be called when the event is fired
				TestApp.MyHandler = new EventHandler(TestApp.Hello);
				
				//Firing the event
				if (TestApp.MyHandler != null){
					TestApp.MyHandler();
				}
			}
			
		}	
		
	}
