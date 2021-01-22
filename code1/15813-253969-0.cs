    public class GoodVigilante
    {
      public event EventHandler LaunchMissiles;
    
      public void Evaluate()
      {
        Action a = DetermineCourseOfAction(); // method that evaluates every possible
    // non-violent solution before resorting to 'Unleashing the fury'
        if (null != a) 
        { a.Do(); }
        else
        {  if (null != LaunchMissiles) LaunchMissiles(this, EventArgs.Empty); }
    
        .... 
    }
    public class TriggerHappy : GoodVigilante
    {
      public void WhatsTheTime()
      {
        if (null != LaunchMissiles) LaunchMissiles(this, EventArgs.Empty);
      }
    
    }
    
    // client code
    GoodVigilante a = new GoodVigilante();
    a.LaunchMissiles += new EventHandler(FireAway);
    GoodVigilante b = new TriggerHappy();             // rogue/imposter
    b.LaunchMissiles += new EventHandler(FireAway);
    
    private void FireAway(object sender, EventArgs e)
    {
      // nuke 'em
    }
