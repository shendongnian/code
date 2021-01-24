    class Song
    {
        private string title;  //--> this is the "backing field" for the property "Title"
        public string artist;
        public int duration;
        public Song(string aTitle, string aArtist, int aDuration)
        {
            //title = aTitle; //--> this only sets the backing field...not the "Title" property
            Title = aTitle;  //--> this sets your "Title" property
            artist = aArtist;
            duration = aDuration;
        }
