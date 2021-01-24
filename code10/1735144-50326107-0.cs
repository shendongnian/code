    public void Log(string message,Source source) // Source is Enum to check to print on screen or file or both for example
    {
         switch(source)
            {
              Case Source.Screen:
                    Console.WriteLine(message);
                    break;
              Case Source.Log:
                   Log.Debug(message);
                   break;
              default:
                 break;
            }
    }
