    internal class UserArgs
    {
        internal string UserName { get; set; }
        internal string TargetNumber { get; set; }
    }
    var args = new UserArgs() {UserName="Me", TargetNumber="123" };
    startCallWorker.RunWorkerAsync(args);
