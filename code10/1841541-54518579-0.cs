    class Song
    {
       public string name;
        string artist;
        int copiesSold;
    
        public Song(string name, string artist, int copiesSold)
        {
            this.name = name;
            this.artist = artist;
            this.copiesSold = copiesSold;
        }
    
        public Song():this("my_name","my_artist",1000)
        {
        }
    	
   	}
