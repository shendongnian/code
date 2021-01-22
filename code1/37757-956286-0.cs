   public abstract class Operation
   {
      #region public Event Handlers
      /// <summary>
      /// The event that updates the progress of the operation
      /// </summary>
      public event OperationProgressChangedEventHandler OperationProgressChanged;
      /// <summary>
      /// The event that notifies that the operation is complete (and results)
      /// </summary>
      public event OperationCompletedEventHandler OperationCompleted;
      #endregion
      #region Members
      // Whether or not we can cancel the operation
      private bool mWorkerSupportsCancellation = false;
      // The task worker that handles running the operation
      private BackgroundWorker mOperationWorker;
      // The operation parameters
      private object[] mOperationParameters;
      #endregion
      /// <summary>
      /// Base class for all operations
      /// </summary>
      public Operation(params object[] workerParameters)
      {
         mOperationParameters = workerParameters;
         // Setup the worker
         SetupOperationWorker();
      }
      #region Setup Functions
      /// <summary>
      /// Setup the background worker to run our Operations
      /// </summary>
      private void SetupOperationWorker()
      {
         mOperationWorker = new BackgroundWorker();
         mOperationWorker.WorkerSupportsCancellation = mWorkerSupportsCancellation;
         mOperationWorker.WorkerReportsProgress = true;
         mOperationWorker.WorkerSupportsCancellation = true;
         mOperationWorker.DoWork += new DoWorkEventHandler(OperationWorkerDoWork);
         mOperationWorker.ProgressChanged += new ProgressChangedEventHandler(OperationWorkerProgressChanged);
         mOperationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OperationWorkerRunWorkerCompleted);
      }
      #endregion
      #region Properties
      /// <summary>
      /// Whether or not to allow the user to cancel the operation
      /// </summary>
      public bool CanCancel
      {
         set
         {
            mWorkerSupportsCancellation = value;
         }
      }
      #endregion
      #region Operation Start/Stop Details
      /// <summary>
      /// Start the operation with the given parameters
      /// </summary>
      /// <param name="workerParameters">The parameters for the worker</param>
      public void StartOperation()
      {
         // Run the worker
         mOperationWorker.RunWorkerAsync(mOperationParameters);
      }
      /// <summary>
      /// Stop the operation
      /// </summary>
      public void StopOperation()
      {
         // Signal the cancel first, then call cancel to stop the test
         if (IsRunning())
         {
            // Sets the backgroundworker CancelPending to true, so we can break
            // in the sub classes operation
            mOperationWorker.CancelAsync();
            // This allows us to trigger an event or "Set" if WaitOne'ing
            Cancel();
            // Wait for it to actually stop before returning
            while (IsRunning())
            {
               Application.DoEvents();
            }
         }
      }
      /// <summary>
      /// Whether or not the operation is currently running
      /// </summary>
      /// <returns></returns>
      public bool IsRunning()
      {
         return mOperationWorker.IsBusy;
      }
      #endregion
      #region BackgroundWorker Events
      /// <summary>
      /// Fires when the operation has completed
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OperationWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         // Allow the sub class to clean up anything that might need to be updated
         Clean();
         // Notify whoever is register that the operation is complete
         if (OperationCompleted != null)
         {
            OperationCompleted(e);
         }
      }
      /// <summary> 
      /// Fires when the progress needs to be updated for a given test (we might not care)
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OperationWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         // Notify whoever is register of what the current percentage is
         if (OperationProgressChanged != null)
         {
            OperationProgressChanged(e);
         }
      }
      /// <summary>
      /// Fires when we start the operation (this does the work)
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OperationWorkerDoWork(object sender, DoWorkEventArgs e)
      {
         // Run the operation
         Run(sender, e);
      }
      #endregion
      #region Abstract methods
      /// <summary>
      /// Abstract, implemented in the sub class to do the work
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected abstract void Run(object sender, DoWorkEventArgs e);
      /// <summary>
      /// Called at the end of the test to clean up anything (ex: Disconnected events, etc)
      /// </summary>
      protected abstract void Clean();
      /// <summary>
      /// If we are waiting on something in the operation, this will allow us to
      /// stop waiting (ex: WaitOne).
      /// </summary>
      protected abstract void Cancel();
      #endregion
   }
