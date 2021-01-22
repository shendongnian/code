    private Play UpdatePlay()
    {
        using (RepositoryContext context = new RepositoryContext())
        {
            HttpRequest http = new HttpRequest();
            PlayRepository rep = new PlayRepository(context);
            ActorRepository actRep = new ActorRepository(context);
	    ReviewsRepository revRep = new ReviewsRepository(context);
            TheatreRepository insRep = new TheatreRepository(context);
            PartRepository partRep = new PartRepository(context);
            Parser p = new Parser();
            XDocument doc = http.GetPlayInfo();
            Theatre theatre = p.ParseTheatreInfo(doc);
            List<Actor> actors = p.ParseActorInfo(doc);
            List<PlayReviews> playReviews = p.ParseReviewsInfo(doc);
            for (int i = 0; i < actors.Count; i++)
            {
                actors[i] = actRep.AddOrUpdate(actors[i]);
            }
            for (int i = 0; i < playReviews.Count; i++)
            {
                playReviews[i].Reviews = revRep.AddOrUpdate(playReviews[i].Reviews);
            }
            theatre = insRep.AddOrUpdate(theatre);
            Play play = p.ParsePlayInfo(doc);
            List<Part> parts = GetParts(play);
            for (int i = 0; i < parts.Count; i++)
            {
                List<Actor> lec = (List<Actor>)parts[i].Actors;
                for (int j = 0; j < lec.Count; j++)
                {
                    lec[j] = actRep.AddOrUpdate(lec[j]);
                }
            }
            play = rep.AddOrUpdate(play);
            context.LoadProperty(play, o => o.Theatre);
            context.LoadProperty(play, o => o.Actors);
            context.LoadProperty(play, o => o.PlayReviewss);
            context.LoadProperty(play, o => o.Parts);
            rep.Save();
            if (play.Theatre != theatre)
                play.Theatre = theatre;
            play = rep.AddParts(parts, play);
            play = rep.AddActor(actors, play);
            for (int i = 0; i < playReviews.Count; i++)
            {
                playReviews[i].Play = play;
                playReviews[i] = revRep.AddPlayInformation(playReviews[i]);
            }
            rep.Save();
            return play;
        }
    }
