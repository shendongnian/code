    class Tournament
      public int Id { get; set; }
      public string Name { get; set; }
      //relationship to schedule
      public ICollection<Schedule> Schedule { get; set; }
    
    class Schedule
      public int Id { get; set; }
      public DateTime Date { get; set; }
    
      //relation to game
      public Game Game { get; set; }
      public int GameId { get; set; }
    
    class Game
      public int Id { get; set; }
    
      //relation to schedule
      [JsonIgnore] //ignore when serializing with NewtonSoft.Json   
      public ICollection<Schedule> Schedule { get; set; }
