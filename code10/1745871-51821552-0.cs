       double yaxis = 0;
        private async void ScrolledUp(object sender, EventArgs e)
        {
            try
            {
                yaxis = yaxis + 25;
                if (yaxis > 125)
                {
                    yaxis = 0;
                }
                await scroll.ScrollToAsync(0, yaxis, false);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
