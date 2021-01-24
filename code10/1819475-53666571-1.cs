    namespace YourApp.Views
    {
        public class MainPage : ContentPage
        {
            PollingTimer timer;
            public MainPage ()
            {
                //PUT UI CODE HERE
                Content = layout;
                //Instantiate Polling timer to call handleaction every 5 seconds
                timer = new PollingTimer(TimeSpan.FromSeconds(5), HandleAction);
                
            }
    
    
            /// <summary>
            /// When the page enters the users view, this procedure is called.
            /// </summary>
            protected override void OnAppearing()
            {
                base.OnAppearing();
                //Handle action and start your timer
                HandleAction();
                timer.Start();
            }
    
            /// <summary>
            /// When the page disappears from the users view this procedure is called.
            /// </summary>
            protected override void OnDisappearing()
            {
                base.OnDisappearing();
                //Stop your timer
                timer.Stop(); //Stop the timer
            }
    
    
            /// <summary>
            /// Callback for the timer.
            /// </summary>
            void HandleAction()
            {
                //Make call to your api to get data
                //Compare data with data you currently have
                // Do whatever you want.
            }
