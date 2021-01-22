    public void Detach()
    {
       GetType().GetMethod("Initialize", BindingFlags.Instance |         
          BindingFlags.NonPublic).Invoke(this, null);
    }
