                if (!this.DataWorkspace.ApplicationData.WorkCalendars.CanDelete)
                {
                    this.ShowMessageBox("", "", MessageBoxOption.Ok);
                    return;
                }
                if (this.WorkCalendars.SelectedItem != null)
                {
                    if ((this.WorkCalendars.SelectedItem.FindCalendarWPs.Count() > 0) || (this.WorkCalendars.SelectedItem.FindCalendarWPs1.Count() > 0))
                    {
                        Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke
            (() =>
            {
                RadWindow.Alert(" ");
            });
                        return;
                    }
                    var y = DataWorkspace.ApplicationData.WorkCalendarDays.Where(w => w.WorkCalendar.Id == WorkCalendars.SelectedItem.Id).Execute().AsEnumerable();
                    foreach (var item in y)
                    {
                        if(item.WorkingHoursCollection != null && item.WorkingHoursCollection.Count() > 0)
                            foreach (var WH in item.WorkingHoursCollection)
                            {
                                WH.Delete();
                            }
                        item.Delete();
                    }
                    if (this.WorkCalendars.SelectedItem == this.DataWorkspace.ApplicationData.WorkCalendars.Where(U => U.Id == this.WorkCalendars.SelectedItem.Id).SingleOrDefault())
                    {
                        Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke
           (() =>
           {
               RadWindow.Alert(" ");
           });
                        return;
                    }
                       
                    this.WorkCalendars.SelectedItem.Delete();
                    this.Save();
                }
            }
            catch (Exception ex)
            {
                Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke
              (() =>
              {
                  var msg = new LightSwitchApplication.Presentation.GeneralViews.ExceptionMessage();
                  msg.DataContext = ex;
                  msg.ShowDialog();
              });
            }
