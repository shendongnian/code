    public void Read()
    {
        this.Open();
        this.TurnToPage(1);
        while(!this.AtLastPage)
        {
            ReadText(this.CurrentPage.Text);
            this.TurnPage();
        }
        this.Close();
    }
