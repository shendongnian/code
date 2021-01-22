	public static SecureString getPasswordFromConsole(String displayMessage) {
		SecureString pass = new SecureString();
		Console.Write(displayMessage);
		ConsoleKeyInfo key;
		do {
			key = Console.ReadKey(true);
			// Backspace Should Not Work
			if (!char.IsControl(key.KeyChar)) {
				pass.AppendChar(key.KeyChar);
				Console.Write("*");
			} else {
				if (key.Key == ConsoleKey.Backspace && pass.Length > 0) {
					pass.RemoveAt(pass.Length - 1);
					Console.Write("\b \b");
				}
			}
		}
		// Stops Receving Keys Once Enter is Pressed
		while (key.Key != ConsoleKey.Enter);
		return pass;
	}
