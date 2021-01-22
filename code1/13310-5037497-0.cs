    public class TestParser
    {
        public static void Main()
        {
            IniParser parser = new IniParser(@"C:\test.ini");
     
            String newMessage;
     
            newMessage = parser.GetSetting("appsettings", "msgpart1");
            newMessage += parser.GetSetting("appsettings", "msgpart2");
            newMessage += parser.GetSetting("punctuation", "ex");
     
            //Returns "Hello World!"
            Console.WriteLine(newMessage);
            Console.ReadLine();
        }
    }
