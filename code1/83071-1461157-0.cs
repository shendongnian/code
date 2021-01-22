// C#
interface IRunnable
{
    void Run();
}
var runnable = new IRunnable()
{
   public void Run()
   {
      Console.WriteLine("Running...");
      // Do your running
   }
};
runnable.Run();
