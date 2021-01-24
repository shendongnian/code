    webView.EvaluateJavascript("javascript: callJS();", new EvaluateBack());
    class EvaluateBack : Java.Lang.Object,IValueCallback
        {
            public void OnReceiveValue(Object value)
            {
                
                Toast.MakeText(Android.App.Application.Context, value.ToString(), ToastLength.Short).Show();// you will get the value "100"
            }
        }
