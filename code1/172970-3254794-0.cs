    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    class Program
    {
      [STAThread]
      static void Main()
      {
        // Set up the UI and run it.
        var program = new Program
        {
          startButton = new Button
          {
            Text = "Start",
            Height = 23, Width = 75,
            Left = 12, Top = 12,
          },
          cancelButton = new Button
          {
            Text = "Cancel",
            Enabled = false,
            Height = 23, Width = 75,
            Left = 93, Top = 12,
          },
          progressBar = new ProgressBar
          {
            Width = 156, Height = 23,
            Left = 12, Top = 41,
          },
        };
        var form = new Form
        {
          Controls =
            {
              program.startButton,
              program.cancelButton,
              program.progressBar
            },
        };
        program.startButton.Click += program.startButton_Click;
        program.cancelButton.Click += program.cancelButton_Click;
        Application.Run(form);
      }
      public Button startButton;
      public Button cancelButton;
      public ProgressBar progressBar;
      private CancellationTokenSource cancellationTokenSource;
      private void startButton_Click(object sender, EventArgs e)
      {
        this.startButton.Enabled = false;
        this.cancelButton.Enabled = true;
        this.cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = this.cancellationTokenSource.Token;
        var progressReporter = new ProgressReporter();
        var task = Task.Factory.StartNew(() =>
        {
          for (int i = 0; i != 100; ++i)
          {
            // Check for cancellation
            cancellationToken.ThrowIfCancellationRequested();
            Thread.Sleep(30); // Do some work.
            // Report progress of the work.
            progressReporter.ReportProgress(() =>
            {
              // Note: code passed to "ReportProgress" may access UI elements.
              this.progressBar.Value = i;
            });
          }
          // Uncomment the next line to play with error handling. 
          //throw new InvalidOperationException("Oops..."); 
          // The answer, at last! 
          return 42;
        }, cancellationToken);
        // ProgressReporter can be used to report successful completion,
        //  cancelation, or failure to the UI thread. 
        progressReporter.RegisterContinuation(task, () =>
        {
          // Update UI to reflect completion. 
          this.progressBar.Value = 100;
          // Display results. 
          if (task.Exception != null)
            MessageBox.Show("Background task error: " + task.Exception.ToString());
          else if (task.IsCanceled)
            MessageBox.Show("Background task cancelled");
          else
            MessageBox.Show("Background task result: " + task.Result);
          // Reset UI. 
          this.progressBar.Value = 0;
          this.startButton.Enabled = true;
          this.cancelButton.Enabled = false;
        });
      }
      private void cancelButton_Click(object sender, EventArgs e)
      {
        this.cancellationTokenSource.Cancel();
      }
    }
