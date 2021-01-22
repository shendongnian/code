    Class MyClass
    {
         private string m_Username = string.Empty;
         private int m_Targetnumber;
         public MyClass(){}
         public string Username
         {
             get { return m_Username; }
             set { m_Username = value; }
         }
         public int TargetNumber
         {
             get { return m_TargetNumber; }
             set { m_TargetNumber = value; }
         }
     }
    // setup/init:
    BackgroundWorker startCallWorker = new BackgroundWorker();
    startCallWorker.DoWork += new DoWorkEventHandler(StartCallWorker_DoWork);
    ...
    MyClass thisClass = new MyClass();
    thisClass.Username = "abcd";
    thisClass.TargetNumber = 1234;
    startCallWorker.RunWorkerAsync(thisClass);
    // the handler:
    private void StartCallWorker_DoWork(object sender, DoWorkEventArgs e)
    {
         MyClass args = (MyClass)e.Argument;
         string userName = args.Username;
         string targetNumber = args.TargetNumber;
    }
