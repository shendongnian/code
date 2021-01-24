               private void ComboBox_SelectionChanged(object sender,
               SelectionChangedEventArgs e)
              {
                  var cmbSender = sender as ComboBox;
                  var state = (Motor.STATE) cmbSender.SelectedItem;
                  mainVm.SetState(state);
              }
