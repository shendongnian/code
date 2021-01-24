    public void ValueChanged(ITable source, string key, Value value, NotifyFlags flags)
        {
            switch (key)
            {
                case @"AUTON_OPTIONS":
                    updateAutonOptions(value.GetStringArray());
                    break;
                case @"POSITION_OPTIONS":
                    updatePositionOptions(value.GetStringArray());
                    break;
                case @"AUTON_FOUND":
                    updateAutonFound(value.GetString());
                    break;
                default:
                    //StackPanel formItem = null;
                    RobotData.Dispatcher.Invoke(() =>
                    {
                        var formItem = LogicalTreeHelper.FindLogicalNode(RobotData, key);
                        //});
                        if (formItem == null)
                        {
                            //Dispatcher.Invoke(() =>
                            //{
                            StackPanel stackPanel = new StackPanel
                            {
                                Name = key,
                                Orientation = Orientation.Horizontal
                            }; //new stackpanel for new data type
                            Label label = new Label
                            {
                                Content = key
                            }; //new label for key name
                            TextBox textBox = new TextBox
                            {
                                IsReadOnly = true,
                                Text = value.GetObjectValue().ToString()
                            }; //new textbox for value data
                            stackPanel.Children.Add(label); //add label to new stackpanel
                            stackPanel.Children.Add(textBox); //add textbox to new stackpanel
                            RobotData.Children.Add(stackPanel);//add new stackpanel to RobotData stackpanel (declared in xaml) 
                                                               //});
                        }
                    
                       else
                       {
                           foreach(Object o in ((StackPanel)formItem).Children)
                           {
                               if(o is TextBox)
                               {
                                   ((TextBox)o).Text = value.GetString();
                                   break;
                               }
                           }
                       }
                    });
                    break;
                    
            }
        }
