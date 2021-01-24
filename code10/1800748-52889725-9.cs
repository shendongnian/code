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
