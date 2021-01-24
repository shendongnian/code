    private Func<User, bool>[] Requires = { get; } = new [] 
    { 
          user => user != null, 
          user => user.isBot,
          user => user.GetClient() != null, 
          user => user.GetClient().GetData() != null,
          user => user.GetClient().GetData().CurrentRoomId == _room.RoomId
    }
    public bool IsValid(User user) => Requires.All(r => r(user))
