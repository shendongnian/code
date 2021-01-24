    private void ShowSendButton()
        {
            if (sendbtn.Visibility != ViewStates.Visible)
            {
                sendbtn.Visibility = ViewStates.Visible;
                sendbtn.ClearAnimation();
                Animation fadeIn = new AlphaAnimation(0, 1);
                fadeIn.Duration = 50;
                sendbtn.Animation = fadeIn;
                
            }
            
        }
