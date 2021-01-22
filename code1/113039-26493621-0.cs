        void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            bool b = e.NavigationMode == NavigationMode.Forward;
            if (b)
            {
                e.Cancel = true;
            }
        }
