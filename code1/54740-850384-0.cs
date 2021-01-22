    public struct RoomId
    {
        private int _Value;
        public static implicit operator RoomId(int value)
        {
            return new RoomId { _Value = value };
        }
        public static implicit operator int(RoomId value)
        {
            return value._Value;
        }
    }
    // ...
    RoomId id = 42;
    Console.WriteLine(id == 41);    // False
    Console.WriteLine(id == 42);    // True
    Console.WriteLine(id < 42);     // False
    Console.WriteLine(id > 41);     // True
    Console.WriteLine(id * 2);      // 84
