    using Microsoft.Toolkit.Uwp.UI.Animations;
    
    private void Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {    
      imageBackdrop.Fade(0.5f, 50).Scale(1.1f, 1.1f,0,0,0).Blur(75, 0).Offset(0, 20, 0).Start();
    }
    
    private void Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {    
      imageBackdrop.Opacity = 0;
    }
