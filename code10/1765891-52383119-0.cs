    class OnSuccessListner : Java.Lang.Object, IOnSuccessListener
    {
        TaskCompletionSource<string> _tcs;
        public OnSuccessListner(TaskCompletionSource<string> tcs)
        {
            _tcs = tcs;
        }
        void IOnSuccessListener.OnSuccess(Java.Lang.Object result)
        {
            var link = result.JavaCast<IShortDynamicLink>();
            _tcs.TrySetResult(link.ShortLink.ToString());
        }
    }
