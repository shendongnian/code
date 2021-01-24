          public static ProgressBar GetProgressBar(Activity _activity)
            {
                var progressBar = new ProgressBar(_activity, null, Android.Resource.Attribute.ProgressBarStyleLarge);              
                progressBar.Visibility=ViewStates.Visible;  //To show ProgressBar
                progressBar.Visibility=ViewStates.Gone;     // To Hide ProgressBar
                return progressBar;
            }
