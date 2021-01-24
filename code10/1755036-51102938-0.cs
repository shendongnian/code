    using System;
    using static System.Console;
    static void Main(string[] args) {
        bool restart = true;
        while (restart) {
            restart = false;
            WriteLine("Please enter a command.");
            string response = ReadLine();
            switch (response) {
                case "setserver": SetServer(); break;
                case "restart": restart = true; break;
            }
        }
	    ReadKey();
    }
    static void ChangePassword() {
        WriteLine("Enter a password.");
        string password = ReadLine();
        WriteLine("Enter a server name.");
        string server = ReadLine();
    }
