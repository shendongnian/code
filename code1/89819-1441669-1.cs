    public bool Enabled
    {
      set
      {
        if (value || !r1.checked) {
          r1.Enabled = value;
        }
        if (value || !r2.checked) {
          r2.Enabled = value;
        }
      }
    }
