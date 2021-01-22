    class Program
    {
        static void Main(string[] args)
        {
            var blocks = new int[,] {{1,2,3,4,5,6},{7,8,9,10,11,12},{13,14,15,16,17,18},{19,20,21,22,23,24}};
            var position = blocks.FirstPositionOf(14);
            Console.WriteLine(position.X + "," + position.Y + " has the element " + blocks[position.X,position.Y]);
        }
    }
    class PositionTuple
    {
        public int X {get; set;}
        public int Y {get; set;}
    }
    static class ArrayExtensions
    {
        public static IEnumerable<int> AsEnumerable(this int[,] someTwoDimensionalArray)
        {
            foreach (var num in someTwoDimensionalArray)
                yield return num;
        }
        public static PositionTuple FirstPositionOf(this int[,] someTwoDimensionalArray, int someNumber)
        {
            return someTwoDimensionalArray
                .AsEnumerable()
                .Select((num, index) => new { Number = num, Tuple = new PositionTuple { X = index / (someTwoDimensionalArray.GetUpperBound(1) + 1), Y = index % (someTwoDimensionalArray.GetUpperBound(1)+1) }})
                .Where(pair => pair.Number == someNumber)
                .Select(pair => pair.Tuple)
                .First();
        }
    }
