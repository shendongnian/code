    ...
        //This is what I'm having trouble with
        public FitHeaderCard GetFitHeaderCard(string _keyword)
        {
            fitHeaderCard = HeaderBlock.Find(delegate (FitHeaderCard item) { return item.keyword == "BITPIX"); };
            fitHeaderCard = new FitHeaderCard(fitHeaderCard); // clone constructor
            return fitHeaderCard;
        }
    }
