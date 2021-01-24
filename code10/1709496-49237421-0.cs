    //defining Grid
        Grid post = new Grid();
        post.HorizontalAlignment = HorizontalAlignment.Left;
        post.VerticalAlignment = VerticalAlignment.Top;
        post.Margin = new Thickness(10);
        post.ShowGridLines = true;
        post.ColumnDefinitions.Add(new ColumnDefinition()
        {
            Width = new GridLength(500)
        });
        //add local field to keep track of what row you're on
        int rowdeff = 0;
        //loop trough all RSS feeds
        foreach (SyndicationItem item in feed.Items)
        {
            //add rows for title and Summary
            post.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(50),
                
            });
            post.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(50)
            });
            
            //create the textblocks
            TextBlock TitleTextblock = new TextBlock;
            TextBlock SummaryTextblock = new TextBlock;
            //add content to textblocks
            TitleTextBlock.Text = item.Title.Text;
            SummaryTextblock.Text = item.Summary.Text;
            //set definitions
            Grid.SetColumn(TitleTextblock, 0);
            Grid.SetColumn(SummaryTextblock, 1);
            Grid.SetRow(TitleTextblock, rowdeff);
            Grid.SetRow(SummaryTextblock, rowdeff);
            //fills textblocks
            post.Children.Add(TitleTextBlock);
            post.Children.Add(SummaryTextblock);
          
            //add next row
            rowdeff++;
        }
        //show grid on window
        this.Content = post;
