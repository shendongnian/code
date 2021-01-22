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
    
            // do stuff
            string username = "<nickname>";
            IUserCollection users = skype.SearchForUsers(username);
            if (users.Count > 0)
            {
                User user = users[1];
                Console.WriteLine(user.FullName);
            }
    
            skype.SendMessage(username, "Hello World");
        }
    }
