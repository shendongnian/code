     Microsoft.Office.Core.CommandBar cb = this.Application.CommandBars["Text"];
     Office.CommandBarControl newButton = cb.Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, missing, missing);  
     newButton.Caption = "Test";
     newButton.Visible = true;
     newButton.Enabled = true;
