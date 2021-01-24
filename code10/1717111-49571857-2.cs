    private Func<User, bool>[] Requires = { get; } = new [] 
    { 
          user => user?.isBot == true,
          // Comparing the expression returning Nullable<bool> with true
          // implicitly converts it to bool
          user => (user?.GetClient()?.GetData()?.CurrentRoomId == room.RoomId) == true
    }
    public bool IsValid(User user) => Requires.All(r => r(user))
