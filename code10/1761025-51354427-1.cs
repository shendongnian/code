    public class Main.cs
    {
      const float gap = 20.0f;
      Table[] script_table;
      bool start_timer = false;
      int t_no;
      public static string Ctimer = "";
    
      public void Update()
      {
        for ( int i = 0; i < script_table.Length; i++ )
          script_table[i].UpdateTimer(Time.deltaTime);
      }
    
      // This method can now be used to Activate or De-Activate a timer.
      public void ActivateTimer ( int tableNumber, bool activate = true )
      {
        script_table[tableNumber ].ActivateTimer( activate );
      }
    }
