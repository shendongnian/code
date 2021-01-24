          foreach (SyndicationItem episode in feed.Items)
          {
              var episodeName = episode.Title.Text;
              var episodeDesc = episode.Summary.Text;
              podcastEpisodes.Add(episodeName);
              episodeDescription.Add(episodeDesc);
          }
