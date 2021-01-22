    void Recursive(Control c)
    {
      c.SuspendLayout();
      try
      {
        if (existCondition) return;
        // do stuff
        Recursive(c);
      }
      finally
      {
        c.ResumeLayout(true);
      }
    }
       
