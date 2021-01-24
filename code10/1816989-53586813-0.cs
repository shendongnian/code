    var CalendarioClick = new TapGestureRecognizer();
                  CalendarioClick.Tapped += async (s, e) =>
                      {
                          CmdCalendario.BackgroundColor = Color.Pink;
                          //Delay 2000ms, change the time you want here
                          await Task.Delay(2000);
                          Navigation.PushAsync(new CalendarioFiscal());
            
                      }; 
            CmdCalendario.GestureRecognizers.Add(CalendarioClick);
