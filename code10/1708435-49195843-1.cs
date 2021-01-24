     private void myWindowName_Loaded(object sender, RoutedEventArgs e)
     {
          //Reference System.Windows.Media.Animation;
          Storyboard storyBoardIn = (Storyboard)TryFindResource("sb2");
          storyBoardIn.Begin();
     }
