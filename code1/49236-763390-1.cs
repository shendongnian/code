    class Program
    {
      static void Main(string[] args)
      {
        CustomClass customClass = new CustomClass();
        ThreadPool.QueueUserWorkItem(x => CallBack(customClass, "Hello")); 
        Console.Read();
      }
      private static void CallBack(CustomClass custom, string text)
      {
        customClass.SaveData(text);
      }
    }
