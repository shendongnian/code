    public class MyViewModel : BaseViewModel // From MVVM Helpers nuget
    {
        private IEnumerable<int> count;
        public IEnumerable<int> Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }
    }
