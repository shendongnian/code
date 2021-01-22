        void MyNonAsyncFunction()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                await Task.Delay(1000);
                MessageBox.Show("Thank you for waiting");
            });
        }
