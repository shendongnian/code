    class Box
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Volume => Height * Width * Length;
        public Box(int length, int height, int width)
        {
            Length = length;
            Height = height;
            Width = width;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Length = {0}, Height = {1}, Width = {2}, Volume = {3}", 
                Length, Height, Width, Volume);
        }
    }
