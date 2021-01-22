    class Program
	{
		static void Main(string[] args)
		{
			Contact contact = new Contact();
			Console.WriteLine("Please enter the person's name:");
			contact.Name = Console.ReadLine();
			Console.WriteLine("Please enter the person's e-mail address:");
			contact.Email = Console.ReadLine();
			while (contact.Favoritecolor == 0)
			{
				Console.WriteLine("Please enter the person's favorite color:");
				string tempColor = Console.ReadLine();
				try
				{
					contact.Favoritecolor = (System.Drawing.KnownColor)(Enum.Parse(typeof(System.Drawing.KnownColor), tempColor, true));
				}
				catch
				{
					Console.WriteLine("The color \"" + tempColor + "\" was not recognized. The known colors are: ");
					foreach (System.Drawing.KnownColor color in Enum.GetValues(typeof(KnownColor)))
					{
						Console.WriteLine(color);
					}
				}
			}
		}
		class Contact
		{
			//This string represents the person's Name.
			public string Name { get; set; }
			//This string represents the person's Email.
			public string Email { get; set; } 
			public System.Drawing.KnownColor Favoritecolor
			{
				get;
				set;
			}
		}
	}
