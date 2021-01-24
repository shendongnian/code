    public abstract class CustomContentPage : ContentPage
    {
        private bool _appeared;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!_appeared)
            {
                OnFirstAppearing();
                _appeared = true;
            }
        }
        protected abstract void OnFirstAppearing();
    }
