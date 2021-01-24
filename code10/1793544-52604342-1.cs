    class Room
    {
        public double Length { get; }
        public double Width { get; }
        public Room(double length, double width)
        {
            // Validation here, for instance throw exception if length <= 0
            Length = length;
            Width = width;
        }
    }
