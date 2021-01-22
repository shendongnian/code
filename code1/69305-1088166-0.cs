            pnlHost.Controls.Clear();
            
            List<Tweet> tweets = new List<Tweet>();
            //Populate your collection of tweets here
            foreach (Tweet tweet in tweets)
            {
                TweetControl control = new TweetControl();
                control.Tweet = tweet;
                pnlHost.Controls.Add(control);
                control.Dock = DockStyle.Top;
            }
