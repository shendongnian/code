    class Library {
    public int Id {get;set;}
    public List<Area> Areas {get;set;}
    }
    class Area {
    public int Id {get;set;}
    public Library Library {get;set;}
    public int LibraryId {get;set;}
    public List<Corridor> Corridors {get;set;}
    }
    class Corridor {
    public int Id {get;set;}
    public Area Area {get;set;}
    public int AreaId {get;set;}
    public List<Rank> Ranks {get;set;}
    }
    class Rank {
    public int Id {get;set;}
    public Corridor Corridor {get;set;}
    public int CorridorId {get;set;}
    public List<Book> Books {get;set;}
    }
    class Book {
    public int Id {get;set;}
    public Rank Rank {get;set;}
    public int RankId {get;set;}
    public string Name {get;set;}
    }
