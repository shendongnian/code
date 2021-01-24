        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            string fullPath = "";
            Image imageSender = (Image)sender;
            if (imageSender.GestureRecognizers.Count > 0)
            {
                var gesture = (TapGestureRecognizer)imageSender.GestureRecognizers[0];
                fullPath = (string)gesture.CommandParameter;
            }
            DownloadFile(imageSender.Source.GetValue(UriImageSource.UriProperty).ToString());
        }
