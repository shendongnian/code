    bool done;
    List<undergradList> listB = new List<undergradList>();
    
    Console.WriteLine();
    do
    {
    	undergradList ugl = new undergradList(); //create a new instance in loop
    	done = false;
    	try
    	{
    			Console.WriteLine("Enter Student ID.");
    			long userInput1 = Convert.ToInt32(Console.ReadLine());
    			ugl.studID = userInput1;
    
    			Console.WriteLine();
    
    			Console.WriteLine("Enter Student Name.");
    			string userInput2 = Console.ReadLine();
    			ugl.studName = userInput2;
    
    			Console.WriteLine();
    
    			Console.WriteLine("Enter Student DOB. (MM/DD/YY) ");
    			DateTime userInput3 = DateTime.Parse(Console.ReadLine());
    			ugl.dateOfBirth = userInput3;
    
    			Console.WriteLine();
    
    			Console.WriteLine("Enter Student Major.");
    			string userInput4 = Console.ReadLine();
    			ugl.major = userInput4;
    
    			Console.WriteLine();
    
    			Console.WriteLine("Enter Student Previous High School.");
    			string userInput5 = Console.ReadLine();
    			ugl.previousHS = userInput5;
    
    			Console.WriteLine();
    
    			Console.WriteLine("Enter Student Classification.");
    			string userInput6 = (Console.ReadLine());
    			ugl.stdClass = userInput6;
    
    		Console.WriteLine();
    		
    		
    		listB.Add(ugl); //add instance in List
    		
    		
    		Console.WriteLine("Are you done entering students? (y/n)");
    		string answer = Console.ReadLine();
    
    		if (answer == "y")
    		{
    			done = true;
    		}
    		else { Console.WriteLine(); }
    	}
    	catch { Console.WriteLine("Answer invalid, try again."); }
    } while (done == false);
    return list;
