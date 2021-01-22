                Microsoft.Office.Core.CommandBar cellbar = diff.CommandBars["Text"];
                Microsoft.Office.Core.CommandBarButton button = (Microsoft.Office.Core.CommandBarButton)cellbar.FindControl(Microsoft.Office.Core.MsoControlType.msoControlButton, 0, "MYRIGHTCLICKMENU", Missing.Value, Missing.Value);
                if (button == null)
                {
                    // add the button
                    button = (Microsoft.Office.Core.CommandBarButton)cellbar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, Missing.Value, Missing.Value, cellbar.Controls.Count + 1, true);
                    button.Caption = "My Right Click Menu Item";
                    button.BeginGroup = true;
                    button.Tag = "MYRIGHTCLICKMENU";
                    button.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(MyButton_Click);
                }
      
