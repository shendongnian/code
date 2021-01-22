    public T Control<T>(String id) where T : Control
    {
      foreach (Control ctrl in MainForm.Controls.Find(id, true))
      {
        return (T)ctrl; // Form Controls have unique names, so no more iterations needed
      }
    
      throw new Exception("Control not found!");
    }
