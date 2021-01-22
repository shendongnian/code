    using System;
    using SKYPE4COMLib;
    
    class Program
    {
        static void Main(string[] args)
        {
            Skype skype = new Skype();
            if (!skype.Client.IsRunning)
            {
                // start minimized with no splash screen
                skype.Client.Start(true, true);
            }
    
            // wait for the client to be connected and ready
            skype.Attach(6, true);
    
            // access skype objects
            Console.WriteLine("Missed message count: {0}", skype.MissedMessages.Count);
    
            // do some stuff
            Console.WriteLine("Enter a skype name to search for: ");
            string username = Console.ReadLine();
            foreach (User user in skype.SearchForUsers(username))
            {
                Console.WriteLine(user.FullName);
            }
    
            Console.WriteLine("Say hello to: ");
            username = Console.ReadLine();
            skype.SendMessage(username, "Hello World");
        }
    }
