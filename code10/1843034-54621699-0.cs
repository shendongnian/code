        private async void GetSpeechPermission()
        {
            var granted = await CrossSpeechRecognition.Current.RequestPermission();
            if (granted.ToString() == "Available")
            {
                //GO
            }
        }
