     private void MainFrame_OnNavigating(object sender, NavigatingCancelEventArgs e) {
                    var ta = new ThicknessAnimation();
                    ta.Duration = TimeSpan.FromSeconds(0.3);
                    ta.DecelerationRatio = 0.7;
                    ta.To = new Thickness(0 , 0 , 0 , 0);
                    if (e.NavigationMode == NavigationMode.New) {         
                        ta.From = new Thickness(500, 0, 0, 0);                                                  
                    }
                    else if (e.NavigationMode == NavigationMode.Back) {                
                        ta.From = new Thickness(0 , 0 , 500 , 0);                                               
                    }
                     (e.Content as Page).BeginAnimation(MarginProperty , ta);
                }
