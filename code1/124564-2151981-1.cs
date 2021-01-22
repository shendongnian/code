    public void Read()
    {
        while(!this.OnBackPage)
        {
            foreach(Article article in this.CurrentPage.Articles)
            {
                ReadText(article.Text);
            }
        }
    }
