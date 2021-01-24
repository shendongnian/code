     class MyJSInterface : Java.Lang.Object, Java.Lang.IRunnable
     {
        Context context;
        public MyJSInterface (Context context)
        {
            this.context = context;
        }
     
        public void AddNewPlace()
        {
            Toast.MakeText(context, "Hello from C#", ToastLength.Short).Show();
        }
    }
