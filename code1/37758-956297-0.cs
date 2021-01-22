   class TestOperation : Operation
   {
      AutoResetEvent mMsgRec;
      public TestOperation(params object[] workerParameters)
         : base(workerParameters)
      {
         CanCancel = true;
         mMsgRec = new AutoResetEvent(false);
         //mSomeEvent += DoSomething();
      }
      protected override void Cancel()
      {
         mMsgRec.Set();
      }
      protected override void Clean()
      {
         //mSomeEvent -= DoSomething();
      }
      protected override void Run(object sender, DoWorkEventArgs e)
      {
         BackgroundWorker bg = (BackgroundWorker)sender;
         for (int i = 0; !bg.CancellationPending && (i < 90); i++)
         {
            bg.ReportProgress(i);
            Thread.Sleep(100);
         }
         for (int i = 90; !bg.CancellationPending && (i < 100); i++)
         {
            mMsgRec.WaitOne(2000, false);
            bg.ReportProgress(i);
         }
         if (bg.CancellationPending)
         {
            e.Cancel = true;
         }
         else
         {
            e.Result = "Complete"; // Or desired result
         }
      }
   }
