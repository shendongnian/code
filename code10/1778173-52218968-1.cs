    // Main Grid
            if (selectedTheme.Name == "Visual Studio 2013 Dark")
            {
                VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Dark);
                App.StronaGlowna.MainGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF1E1E1E");
            }
            if (selectedTheme.Name == "Visual Studio 2013 Blue")
            {
                VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Blue);
            }
            if (selectedTheme.Name == "Visual Studio 2013")
            {
                VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Light);
                App.StronaGlowna.MainGrid.Background = Brushes.White;
            }
            if (selectedTheme.Name == "Dark")
            {
                VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Dark);
                App.StronaGlowna.MainGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3D3D3D");
            }
            if (selectedTheme.Name == "Green")
            {
                GreenPalette.LoadPreset(GreenPalette.ColorVariation.Dark);
                App.StronaGlowna.MainGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF1D1E21");
            }
            if (selectedTheme.Name == "Green Light")
            {
                GreenPalette.LoadPreset(GreenPalette.ColorVariation.Light);
                App.StronaGlowna.MainGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE0E0E0");
            }
            if (selectedTheme.Name == "Vista" ||
                selectedTheme.Name == "Visual Studio 2013 Blue" || selectedTheme.Name == "Office Black" ||
                selectedTheme.Name == "Office Blue" ||
                selectedTheme.Name == "Office Silver" || selectedTheme.Name == "Summer" ||
                selectedTheme.Name == "Transparent" || selectedTheme.Name == "Windows 7")
            {
                App.StronaGlowna.MainGrid.Background = Brushes.White;
            }
