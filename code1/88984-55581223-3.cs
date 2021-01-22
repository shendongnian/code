    public class Test
    {
        public static void MyExtensionTest()
        {
            ObservableCollection<INotifyPropertyChanged> c = new ObservableCollection<INotifyPropertyChanged>();
            c.SetOnCollectionItemPropertyChanged((item, e) =>
            {
                 //whatever you want to do on item change
            });
        }
    }
