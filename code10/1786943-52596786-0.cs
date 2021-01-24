    using System;
    using System.Globalization;
    using System.Threading;
    
    public class Example
    {
       public static void Main()
       {
          string[] cultureNames = { "en-GB", "en-US", "fr-FR", "ru-RU" };
          Random rnd = new Random();
          string cultureName = cultureNames[rnd.Next(0, cultureNames.Length)]; 
          Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
          Console.WriteLine("The current UI culture is {0}", 
                            Thread.CurrentThread.CurrentUICulture.Name);
          StringLibrary strLib = new StringLibrary();
          string greeting = strLib.GetGreeting();
          Console.WriteLine(greeting);
       }
    }
