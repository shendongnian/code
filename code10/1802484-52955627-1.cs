    private DateTime hitStateTime = default(DateTime);
    private bool hitState; // The "backing store".
    private bool HitState 
    {
      get 
      {
        return hitState;
      }
      set
      {
        hitState = value;
        hitStateSet = DateTime.Now;
      }
    }
