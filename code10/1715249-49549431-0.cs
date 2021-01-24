    mProgressBar = ItemView.FindViewById<ProgressBar>(Resource.Id.progressBar1);
    private async void BtnProcessAction_Click(object sender, EventArgs e)
    {
        mProgressBar.Visibility = ViewStates.Visible;
        await someMethod(); 
        mProgressBar.Visibility = ViewStates.Gone;
    }
