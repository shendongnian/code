    public struct Rating
    {
        public int Lower { get; set; }
        public int Upper { get; set; }
        public int FinalRating { get; set; }
    }
    
    private int GetRating(IEnumerable<Rating> ratings, double rawValue)
    {
        int finalRating
        foreach(var rating in ratings)
        {
            int currentRating;
            if(rawValue >= rating.Lower && rawValue <= rating.Upper)
                currentRating = rating.FinalRating;
            
            Math.Max(currentRating, finalRating);
        }
        return finalRating; 
    }
