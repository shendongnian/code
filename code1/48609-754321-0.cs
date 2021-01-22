    bool mShowButtons;
    [DefaultValue(false)]
    public bool ShowButtons
    {
      get
      {
         return mShowButtons;
      }
      set
      { 
        mShowButtons = value;
        UpdateButtons();
      }
    }
