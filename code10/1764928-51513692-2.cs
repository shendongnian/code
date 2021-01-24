    class Player
    {
        public int Id {get; set;}
        public string Name {get; set;}
        // every Player has zero or more PlayedGames
        public virtual ICollection<PlayedGame> PlayedGames{get; set;}
    }
    class PlayedGame
    {
        public int Id {get; set;}
        public int Score {get; set;}
        // every PlayedGame was played by exactly one Player using foreign key
        public int PlayerId{get; set;}
        public virtual Player Player {get; set;}
    }
