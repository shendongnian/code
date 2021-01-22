    public class FootballTeam { 
      private string _manager;
      public string Manager {
        get { return _manager; }
        set { 
          if ( ManagerChanged != null ) { 
            ManagerChanged(this,EventArgs.Empty);
          }
        }
      }
      public event EventHandler ManagerChanged;
    }
