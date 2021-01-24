    string[] girlsSplit;
    private void NamesGirls_Completed(object sender, EventArgs e)
    {
        var text2 = ((Editor)sender).Text; 
        girlsSplit = text2.Split(','); 
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Wuensche(girlsSplit));
    }
