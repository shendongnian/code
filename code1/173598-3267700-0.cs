    // Supports existance in a room.
    interface IExistInRoom { Room GetCurrentRoom(); }
    
    // Supports moving from one room to another.
    interface IMoveable : IExistInRoom { void SetCurrentRoom(Room room); }
    
    // Supports being involved in a fight.
    interface IFightable
    {
      Int32 HitPoints { get; set; }
      Int32 Skill { get; }
      Int32 Luck { get; }
    }
    
    // Example class declarations.
    class RoomFeature : IExistInRoom
    class Player : IMoveable, IFightable
    class Monster : IMoveable, IFightable
    
    // I'd proably choose to have this method in Game, as it alters the
    // games state over one turn only.
    void Move(IMoveable m, Direction d)
    {
      // TODO: Check whether move is valid, if so perform move by
      // setting the player's location.
    }
    
    // I'd choose to put a fight in its own class because it might
    // last more than one turn, and may contain some complex logic
    // and involve player input.
    class Fight
    {
      public Fight(IFightable[] participants)
    
      public void Fight()
      {
        // TODO: Logic to perform the fight between the participants.
      }
    }
