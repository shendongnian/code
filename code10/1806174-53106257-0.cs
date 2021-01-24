    ...
        //This is what I'm having trouble with
        public FitHeaderCard GetFitHeaderCard(string _keyword)
        {
            fitHeaderCard = HeaderBlock.Find(FilterByBitPix);
            fitHeaderCard = new FitHeaderCard(fitHeaderCard); // clone constructor
            return fitHeaderCard;
        }
        public FitHeaderCard FilterByBitPix(FitHeaderCard item)
        {
            return item.keyword == "BITPIX";
        }
    }
