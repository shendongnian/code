      class MainVM : INotifyPropertyChanged
          {
      
              public List<STATE> States { get; set; }
      
              private string _subState;
              public string SubState
              {
                  get { return _subState; }
                  set { _subState = value; OnPropertyChanged(); }
              }
      
              public MainVM()
              {
                  States = new List<STATE>
                  {
                      STATE.IDLE,
                      STATE.CALIBRATE,
                      STATE.GO_HOME
                  };
      
                  SubState = CurrentState.ToString();
              }
      
             
     
              public void SetState(object selectedState)
              {
                  if(selectedState.ToString() == STATE.IDLE.ToString())
                  {
                      SubState = CurrentState.ToString();
                  }
                  else if(selectedState.ToString() == STATE.CALIBRATE.ToString())
                  {
                      SubState = CalibrateTrackState.ToString();
                  }
                  else
                  {
                      SubState = HomeingState.ToString();
                  }
              }
      
              private STATE _currentState = STATE.IDLE;
              public STATE CurrentState
              {
                  get { return _currentState; }
                 set { _currentState = value; OnPropertyChanged("CurrentState"); }
             }
      
             private CALIBRATE_TRACK _calibrateTrackState = CALIBRATE_TRACK.SUB_STATE_C1;
              public CALIBRATE_TRACK CalibrateTrackState
              {
                  get { return _calibrateTrackState; }
                  set { _calibrateTrackState = value; OnPropertyChanged("CalibrateTrackState"); }
              }
      
              private HOMING _homeingState = HOMING.SUB_STATE_H1;
              public HOMING HomeingState
              {
                  get { return _homeingState; }
                  set { _homeingState = value; OnPropertyChanged("HomeingState"); }
              }
      
              protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
              {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
              }
      
              public event PropertyChangedEventHandler PropertyChanged;
          }
