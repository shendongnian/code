    public class MyForm : Form
    {
      private volatile string m_Text = "";
      private System.Timers.Timer m_Timer;
      private MyForm()
      {
        m_Timer = new System.Timers.Timer();
        m_Timer.SynchronizingObject = this;
        m_Timer.Interval = 1000;
        m_Timer.Elapsed += (s, a) => { MyProgressLabel.Text = m_Text; };
        m_Timer.Start();
        var thread = new Thread(WorkerThread);
        thread.Start();
      }
      private void WorkerThread()
      {
        while (...)
        {
          // Periodically publish progress information.
          m_Text = "Still working...";
        }
      }
    }
