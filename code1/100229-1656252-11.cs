    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Collections.ObjectModel;
    
    namespace Battleship.ShuggyCoUk
    {
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
    
            public static bool IsTouching(this Point a, Point b)
            {
                return (a.X == b.X - 1 || a.X == b.X + 1) &&
                    (a.Y == b.Y - 1 || a.Y == b.Y + 1);
            }
    
            public static bool IsTouching(this Ship ship,
                IEnumerable<Ship> ships,
                Point location,
                ShipOrientation direction)
            {
                var temp = new Ship(ship.Length);
                temp.Place(location, direction);
                var occupied = new HashSet<Point>(ships
                    .Where(s => s.IsPlaced)
                    .SelectMany(s => s.GetAllLocations()));
                if (temp.GetAllLocations().Any(p => occupied.Any(b => b.IsTouching(p))))
                    return true;
                return false;
            }
    
            public static ReadOnlyCollection<Ship> MakeShips(params int[] lengths)
            {
                return new System.Collections.ObjectModel.ReadOnlyCollection<Ship>(
                    lengths.Select(l => new Ship(l)).ToList());       
            }
    
            public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Rand rand)
            {
                T[] elements = source.ToArray();
                // Note i > 0 to avoid final pointless iteration
                for (int i = elements.Length - 1; i > 0; i--)
                {
                    // Swap element "i" with a random earlier element it (or itself)
                    int swapIndex = rand.Next(i + 1);
                    T tmp = elements[i];
                    elements[i] = elements[swapIndex];
                    elements[swapIndex] = tmp;
                }
                // Lazily yield (avoiding aliasing issues etc)
                foreach (T element in elements)
                {
                    yield return element;
                }
            }
    
            public static T RandomOrDefault<T>(this IEnumerable<T> things, Rand rand)
            {
                int count = things.Count();
                if (count == 0)
                    return default(T);
                return things.ElementAt(rand.Next(count));
            }
        }
    }
