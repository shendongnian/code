    public T Control<T>(String id)
    {
      foreach (Control ctrl in MainForm.Controls.Find(id, true))
      {
        return (T)(object)ctrl; 
      }
    
      throw new Exception("Control not found!");
    }
