    private long m_LayoutSuspended = 0;
    public bool SuspendLayout()
    {
        return Interlocked.CompareExchange(ref m_LayoutSuspended, 1) == 0;
    }
    if (o.SuspendLayout()) 
    {
      ....
      o.ResumeLayout();
    }
  
