    private void ShowSendButton()
    {
        if (sendbtn.Visibility != ViewStates.Visible)
        {
            sendbtn.ClearAnimation();
            sendbtn.Animate().Alpha(1.0f).SetDuration(200).WithStartAction(new Runnable(() => {
                sendbtn.Visibility = ViewStates.Visible;
            })).Start();
        }
    }
    private void HideSendButton()
    {
        if (sendbtn.Visibility != ViewStates.Gone)
        {
            sendbtn.ClearAnimation();
            sendbtn.Animate().Alpha(0.0f).SetDuration(200).WithEndAction(new Runnable(() =>
            {
                sendbtn.Visibility = ViewStates.Gone;
            })).Start();
        }
    }
