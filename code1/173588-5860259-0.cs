        private void passwordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
             if (passwordBox2.Password != passwordBox1.Password)
             {
                 //Execute code to alert user passwords don't match here.
                 passwordBox2.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
             }
             else
             {
                 /*You must make sure that whatever you do is reversed here;
                  *all users will get the above "error" whilst typing in and you need to make sure
                  *that it goes when they're right!*/
                 passwordBox2.Background = new SolidColorBrush(Color.FromArgb(255,0,0,0));
              }
        }
                
