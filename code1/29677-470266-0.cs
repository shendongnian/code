    public class SelectionEndListView : ListView
    {
    private System.Windows.Forms.Timer m_timer;
    private const int SELECTION_DELAY = 50;
    
    public SelectionEndListView()
    {
       m_timer = new Timer();
       m_timer.Interval = SELECTION_DELAY;
       m_timer.Tick += new EventHandler(m_timer_Tick);
    }
    
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
       base.OnSelectedIndexChanged(e);
    
       // restart delay timer
       m_timer.Stop();
       m_timer.Start();
    }
    
    private void m_timer_Tick(object sender, EventArgs e)
    {
       m_timer.Stop();
    
       // Perform selection end logic.
       Console.WriteLine("Selection Has Ended");
    }
    }
