    private async void Button_Click(object sender, EventArgs e)
    {
        try
        {
            await Presenter.Search();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = "Error:....";
        }
    }
