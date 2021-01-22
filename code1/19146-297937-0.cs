private delegate int CommandDelegate(string number);
private void ExecuteCommandAsync()
{
    CommandDelegate del = new CommandDelegate(BeginExecuteCommand);
    del.BeginInvoke("four", new AsyncCallback(EndExecuteCommand), null);
}
private int BeginExecuteCommand(string number)
{
   if (number == "five")
   {
      return 5;
   }
   else
   {
      throw new InvalidOperationException("I only understand the number five!");
   }
}
private void EndExecuteCommand(IAsyncResult result)
{
    CommandDelegate del;
    int retVal;
    del = (CommandDelegate)((AsyncResult)result).AsyncDelegate;
    try
    {
        // Here's where we get the return value
        retVal = del.EndInvoke(result);
    }
    catch (InvalidOperationException e)
    {
        // See, we had EndExecuteCommand called, but the exception
        // from the Begin method got tossed here
    }
}
