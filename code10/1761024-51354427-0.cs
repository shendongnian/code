    // If Table.cs is derived from MonoBehaviour, the Update() method can be
    // used to drive the timer. But adds the inherit overhead of being a MonoBehaviour.
    public class Table : MonoBehaviour
    {
      public UILabel info_timer = null;
    
      const float gap = 20.0f;
    
      private float timer;
      public bool isActive { get; private set; } = false;
    
      public void ActivateTimer( bool activate = true)
      {
        // If activate is true, then reset this timer to the default.
        if ( activate )
          timer = gap;
        isActive = activate;
      }
    
      // Use Update to drive the timer from each components Update call? Ignored if this class does not derive from MonoBehaviour.
      public void Update()
      {
        UpdateTimer(Time.deltaTime);
      }
    
      // Use an explicit update method to drive the timer.
      public void UpdateTimer( float deltaTime)
      {
        // We can even check to see if the table is active or the timer has already timed out.
        if ( !isActive ) return;
    
        timer -= deltaTime;
    
        if ( timer <= 0.0f )
        {
          script_table[i].info_timer =  Ctimer = "[808080]0[-]";
          isActive = false;
        }
        else
          script_table[i].info_timer.text = gap.ToString("F0");
      }
    }
