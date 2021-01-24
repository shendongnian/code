    class MyJSInterface : Java.Lang.Object
      {
        Context context;
      public MyJSInterface (Context context)
        {
          this.context = context;
        }
      [JavascriptInterface]
      [Export]
      public void ShowToast (string msg)
        {
          Toast.MakeText(context, msg, ToastLength.Short).Show();
        }
      }
