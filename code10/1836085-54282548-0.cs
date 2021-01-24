	using System;
	namespace SO_console
	{
		class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine("how much do you have on your gift card?");
				string cardString = Console.ReadLine();
				decimal cardAmount;// we dont need to initalize the sum of this variable because we will get that from the user.
				while (!decimal.TryParse(cardString, out cardAmount))//validate
				{
					Console.WriteLine("Please enter how much you have on your gift card!");
					cardString = Console.ReadLine();
				}
				// MODIFIED: changed >= 0 to > 0
				while (cardAmount > 0) //while loop to determine amount after each purchase. 
				{
					Console.WriteLine("how much was your purchase?");
					string purchaseString = Console.ReadLine();
					decimal purchaseAmount;
					while (!decimal.TryParse(purchaseString, out purchaseAmount))// validating user response inside while loop.
					{
						Console.WriteLine("Please enter how much your purchase was!");
						purchaseString = Console.ReadLine();
					}
					cardAmount -= purchaseAmount; // this line is very important! this is how we subtract and get the values we want every time the loop goes through.
					if (cardAmount <= 0)
					{
						Console.WriteLine("With your last purchase of $" + purchaseAmount + ", you have used your gift card up and still owe $" + cardAmount + ".");
						break;
					}
					//Added else clause
					else
					{
						//MOVED: moved this line of code to else claue
						Console.WriteLine("With your current purchase of $" + purchaseAmount + ", you can still spend $" + cardAmount + ".");
					}
				}
				//ADDED: added these line so use can see see last prompt written before program ends
				Console.WriteLine("Press any key to end program");
				Console.ReadKey();
			}
		}
	}
