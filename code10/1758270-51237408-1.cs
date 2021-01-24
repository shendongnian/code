     private void AddZoneButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            MapField.Children.Remove(button);
            if (button.Command != null)
            {
                button.Command.Execute(e);
            }
            zoneControls.Orientation = StackOrientation.Horizontal;
            zoneControls.VerticalOptions = LayoutOptions.End;
            zoneControls.HorizontalOptions = LayoutOptions.FillAndExpand;
            zoneControls.HeightRequest = 35;
            
            MapField.Children.Add(zoneControls);
            zoneControls.Children.Add(saveZoneButton);
            zoneControls.Children.Add(setZonePropsButton);
            zoneControls.Children.Add(deleteZoneButton);
            zoneControls.Children.Add(closeControlsButton);
        }
