    public static void Main(string[] args){
         Task();
         System.Console.WriteLine("main thread is running while waiting");
         Console.ReadLine();
    }
    private static async void Task(){
         await Task.Delay(10000);
         Console.WriteLine("Waited for 10s");
    }
