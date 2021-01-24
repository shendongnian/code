    public class MyActivity: Activity, IOnCompletionListener
    {
           public void OnCompletion(Android.Media.MediaPlayer mp)
            {
                Android.Util.Log.Info("Completion Listener", "Song Complete");
             Toast.MakeText(this, "Media Completed", ToastLength.Short).Show();
            }
    ...
       {
       ...
        mediaPlayer.SetOnCompletionListener(this);
       ...
       }
    }
