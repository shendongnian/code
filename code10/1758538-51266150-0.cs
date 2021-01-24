    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
      }
      Semaphore semaphore = new Semaphore(1, 1);
      private async void button1_Click(object sender, EventArgs e)
      {
        if (!semaphore.WaitOne(0))
        {
          MessageBox.Show("Long running task hasn't finished yet!");
          return;
        }
        await LongRunningTask();
        semaphore.Release();
      }
      public async Task LongRunningTask()
      {
        await Task.Delay(5000);
        MessageBox.Show("Long running finished...");
      }
    }
