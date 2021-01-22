    [DataContract]
    class Artist
    {
       .....
       [DataMember]
       public List<Album> Albums;
       .....
    }
    
    [DataContract]
    class Album
    {
       .....
       int ID;
       .....
       [DataMember]
       public List<Song> Songs;
       .....
    }
    
    [DataContract]
    class Song
    {
       .....
       int ID;
       .....
       [DataMember]
       public string Title;
       .....
    }
