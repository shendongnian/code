    public ObservableCollection<Team> Teams { get;set;}
    public ObservableCollection<Player> Players { get;set;}
    private List<Player> AllPlayers {get;set}
    
    public Team CurrentTeam 
    {
      get
      {
        return this._currentTeam;
      }
      set
      {
        this._currentTeam = value;
        this.Players = new ObservableCollection(this.AllPlayers.Where(x => x.TeamId = this._currentTeam.TeamId));
        RaisePropertyChanged("CurrentTeam");
      }
    }
