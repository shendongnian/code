       //class  under access right protection
		public class Foo
		{
			//Control the access right for ClientA only
			public void S() 
			{ 
			  if (!LicenceManager.ClientA)
				throw new exception ("Not Valid key. Only ClientA licence can use this service");
				
				//do what actions
			}
		   
			//Control ClientC
			public void D() 
			{ 
			   if (!LicenceManager.ClientC)
				throw new exception ("Not Valid key. Only ClientC licence can use this service");
				
				//do what actions
			}
			
		   // and so on for other methods 
		}		
