    public partial class MyForm : Form
    {
      private readonly TaskScheduler _uiTaskScheduler;
      public MyForm()
      {
        InitializeComponent();
        _uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
      }
      private void buttonRunAsyncOperation_Click(object sender, EventArgs e)
      {
        RunAsyncOperation();
      }
      private void RunAsyncOperation()
      {
        var task = new Task<string>(LengthyComputation);
        task.ContinueWith(antecedent =>
                             UpdateResultLabel(antecedent.Result), _uiTaskScheduler);
        task.Start();
      }
      private string LengthyComputation()
      {
        Thread.Sleep(3000);
        return "47";
      }
      private void UpdateResultLabel(string text)
      {
        labelResult.Text = text;
      }
    }
