        void Handle_Clicked(object sender, System.EventArgs e)
        {
    #if ANDROID
            Toast.MakeText(MainActivity.Context, "I'm an Android Toast!", ToastLength.Long).Show();
    #endif
    #if IOS
            var alert = new UIAlertView("I'm an iOS Alert!", "I'm deprecated. but using here because I do not have easy access to my view controller at this time", null, "OK", null);
            alert.Show();
    #endif
        }
