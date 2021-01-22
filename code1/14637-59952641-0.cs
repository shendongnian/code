 lang-cs
// programatically copy selected text into clipboard
await System.Threading.Tasks.Task.Factory.StartNew(fetchSelectionToClipboard);
// access clipboard which now contains selected text in foreground window (active application)
await System.Threading.Tasks.Task.Factory.StartNew(useClipBoardValue);
Here the methods being called:
static void fetchSelectionToClipboard()
{
  Thread.Sleep(400);
  SendKeys.SendWait("^c");   // magic line which copies selected text to clipboard
  Thread.Sleep(400);
}
// depends on the type of your app, you sometimes need to access clipboard from a Single Thread Appartment model..therefore I'm creating a new thread here
static void useClipBoardValue()
{
  Exception threadEx = null;
  // Single Thread Apartment model
  Thread staThread = new Thread(
     delegate ()
       {
          try
          {
             Console.WriteLine(Clipboard.GetText());
          }
          catch (Exception ex)
          {
            threadEx = ex;
          }
      });
  staThread.SetApartmentState(ApartmentState.STA);
  staThread.Start();
  staThread.Join();
}
