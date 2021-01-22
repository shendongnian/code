    System.Windows.Forms.Timer DeferredActionTimer = new System.Windows.Forms.Timer() { Interval = 200 };
    Queue<Action> DeferredActions = new Queue<Action>();
    void DeferredActionTimer_Tick(object sender, EventArgs e) {
      while(DeferredActions.Count > 0) {
        Action act = DeferredActions.Dequeue();
        act();
      }
    }
