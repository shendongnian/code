    class Program
	{
		static void Main(string[] args)
		{
			Contact contact = new Contact();
			Console.WriteLine("Please enter the person's name:");
			contact.Name = Console.ReadLine();
			Console.WriteLine("Please enter the person's e-mail address:");
			contact.Email = Console.ReadLine();
			Console.WriteLine("Please enter the person's favorite color:");
			string tempColor = Console.ReadLine();
			contact.Favoritecolor = (System.Drawing.KnownColor)(Enum.Parse(typeof(System.Drawing.KnownColor), tempColor));
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
