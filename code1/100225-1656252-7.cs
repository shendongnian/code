    public static class Extensions
    {        
        public static bool IsIn(this Point p, Size size)
        {
            return p.X >= 0 && p.Y >= 0 && p.X < size.Width && p.Y < size.Height;
        }
        public static bool IsLegal(this Ship ship,
            IEnumerable<Ship> ships, 
            Size board,
            Point location, 
            ShipOrientation direction)
        {
            var temp = new Ship(ship.Length);
            temp.Place(location, direction);
            if (!temp.GetAllLocations().All(p => p.IsIn(board)))
                return false;
            return ships.Where(s => s.IsPlaced).All(s => !s.ConflictsWith(temp));
        }
        public static ReadOnlyCollection<Ship> MakeShips(params int[] lengths)
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<Ship>(
                lengths.Select(l => new Ship(l)).ToList());       
        }
    }
