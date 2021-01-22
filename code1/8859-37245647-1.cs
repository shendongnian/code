    /// <summary>
    /// A new way to use Tasks for Asynchronous calls
    /// </summary>
    public class Example
    {
        /// <summary>
        /// No more delegates, background workers etc. just one line of code as shown below
        /// Note it is dependent on the XTask class shown next.
        /// </summary>
        public async void ExampleMethod()
        {
            //Still on GUI/Original Thread here
            //Do your updates before the next line of code
            await XTask.RunAsync(() =>
            {
                //Running an asynchronous task here
                //Cannot update GUI Thread here, but can do lots of work
            });
            //Can update GUI/Original thread on this line
        }
    }
    /// <summary>
    /// A class containing extension methods for the Task class 
    /// Put this file in folder named Extensions
    /// Use prefix of X for the class it Extends
    /// </summary>
    public static class XTask
    {
        /// <summary>
        /// RunAsync is an extension method that encapsulates the Task.Run using a callback
        /// </summary>
        /// <param name="Code">The caller is called back on the new Task (on a different thread)</param>
        /// <returns></returns>
        public async static Task RunAsync(Action Code)
        {
            await Task.Run(() =>
            {
                Code();
            });
            return;
        }
    }
