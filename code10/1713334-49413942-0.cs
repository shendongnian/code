        private void FadeOutButtons(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(1)
            };
            fadeAnimation.Completed += CollapseStartPage;
            if((System.Windows.Controls.Button)sender == cmdSettings)
                fadeAnimation.Completed += ShowSettingsScreen;
            if ((System.Windows.Controls.Button)sender == cmdStartGame)
            {
                fadeAnimation.Completed += ShowGameScreen;
                fadeAnimation.Completed += StartGame;
            }
            cmdStartGame.BeginAnimation(System.Windows.Controls.Button.OpacityProperty, fadeAnimation);
            cmdSettings.BeginAnimation(System.Windows.Controls.Button.OpacityProperty, fadeAnimation);
            cmdHistory.BeginAnimation(System.Windows.Controls.Button.OpacityProperty, fadeAnimation);
            cmdAbout.BeginAnimation(System.Windows.Controls.Button.OpacityProperty, fadeAnimation);
        }
