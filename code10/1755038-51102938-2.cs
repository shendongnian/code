    using System;
    using static System.Console;
    private static bool exit = false;
    private static string serverName = string.Empty;
    static void Main(string[] args) {
            WriteLine("Please enter a command.");
            string response = ReadLine();
            switch (response) {
                case "setserver": SetServer(); break;
                case "changepass": ChangePassword(); break;
            }
        }
        ReadKey();
    }
    static void SetServer() {
        WriteLine("Please enter a server name.");
        serverName = ReadLine(); // You should probably validate the user input here.
    }
    static void ChangePassword() {
        // Execute your needed password change code here.
    }
