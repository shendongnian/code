    //Create a base callback-popup. Let any popup that should return something on a button click inherit from this
    public class CallbackPopup<T> : PopupPage
    {
        public Task<T> PagePoppedTask { get { return tcs.Task; } }
        private TaskCompletionSource<T> tcs;
        public CallbackPopup()
        {
            tcs = new TaskCompletionSource<T>();
        }
        
        //Deriving classes have to call this method in the "OnDisappearing" or when a specific button was clicked
        public void SetPopupResult(T result)
        {
            if (PagePoppedTask.IsCompleted == false)
                tcs.SetResult(result);
        }
    }
    //Asyncly call this popup
    public async void OpenPopup(){
            var popup = new YourPopup<bool>();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            bool result = await popup.PagePoppedTask;
    }
