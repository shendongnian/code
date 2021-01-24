        private void BalloonTip_Clicked(object sender, RoutedEventArgs e)
        {
            //do it...
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = "My title";
            string text = "My texte...";
            tbi.TrayBalloonTipClicked += new RoutedEventHandler(BalloonTip_Clicked);
            //show balloon with custom icon
            tbi.ShowBalloonTip(title, text, NotifiyTest_01.Properties.Resources.Error);
            //hide balloon
            tbi.HideBalloonTip();
        } 
