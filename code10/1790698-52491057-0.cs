      public class MyPage : ContentPage
        {
            public void RaiseSomeButtonClicked() => OnSomeButtonClickeded();
    
            private void OnSomeButtonClicked()
            {
                //by using aggregators you can publish any event and subscribe it in you BasePage.xaml.cs 
                ((App)App.Current).Container.Resolve<IEventAggregator>()
                    .GetEvent<SomeButtonClickedEvent>().Publish(new SomeButtonClickedEvent());
            }
        }
