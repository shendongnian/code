    public class Example
    {
        /// <summary>
        /// No more delegates, background workers, etc. Just one line of code as shown below.
        /// Note it is dependent on the Task Extension method shown next.
        /// </summary>
        public async void Method1()
        {
            // Still on the GUI thread here if the method was called from the GUI thread
            // This code below calls the extension method which spins up a new task and calls back.
            await TaskXM.RunCodeAsync(() =>
            {
                // Running an asynchronous task here
                // Cannot update the GUI thread here, but can do lots of work
            });
            // Can update GUI on this line
        }
    }
    /// <summary>
    /// A class containing extension methods for the Task class
    /// </summary>
    public static class TaskXM
    {
        /// <summary>
        /// RunCodeAsyc is an extension method that encapsulates the Task.run using a callback
        /// </summary>
        /// <param name="Code">The caller is called back on the new Task (on a different thread)</param>
        /// <returns></returns>
        public async static Task RunCodeAsync(Action Code)
        {
            await Task.Run(() =>
            {
                Code();
            });
            return;
        }
    }
