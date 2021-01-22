        // Set Weight (Property setting is a string like "Bold")
        FontWeight thisWeight = (FontWeight)new FontWeightConverter().ConvertFromString(Properties.Settings.Default.DealerMessageFontWeightValue);
        // Set Color (Property setting is a string like "Red" or "Black")
        SolidColorBrush thisColor = (SolidColorBrush)new BrushConverter().ConvertFromString(Properties.Settings.Default.DealerMessageFontColorValue);
        // Set the style for the dealer message
        // Font Family Property setting  is a string like "Arial"
        // Font Size Property setting is an int like 12, a double would also work
        Style newStyle = new Style
        {
            TargetType = typeof(TextBlock),
            Setters = {
                new Setter 
                {
                    Property = Control.FontFamilyProperty,
                    Value = new FontFamily(Properties.Settings.Default.DealerMessageFontValue)
                },
                new Setter
                {
                    Property = Control.FontSizeProperty,
                    Value = Properties.Settings.Default.DealerMessageFontSizeValue
                },
                new Setter
                {
                    Property = Control.FontWeightProperty,
                    Value = thisWeight
                },
                new Setter
                {
                    Property = Control.ForegroundProperty,
                    Value = thisColor
                }
            }
        };
        textBlock_DealerMessage.Style = newStyle;
