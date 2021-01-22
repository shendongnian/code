            bool isIn = pts.Pairwise((p1, p2) => Tuple.Create(p1, p2)).Any(tuple => ReadablePredicate(tuple.Item1, tuple.Item2, pt));
            return isIn ? PointInPolygonLocation.Inside : PointInPolygonLocation.Outside;
        }
        public static bool ReadablePredicate(Position p1, Position p2, Position pt)
        {
            if (p1.Y == p2.Y)
                return false;
            if (!((p1.Y >= pt.Y && p2.Y < pt.Y) || (p1.Y < pt.Y && p2.Y >= pt.Y)))
                return false;
            if (p1.X < pt.X && p2.X < pt.X) // Originally was (p1.X < p1.X && ...). that makes no sense, so I assumed you meant p1.X < pt.X
                return true;
            if ((p1.X < pt.X || p2.X < pt.X) && ((pt.Y - p1.Y) * ((p1.X - p2.X) / (p1.Y - p2.Y)) * p1.X) < pt.X)
                return true;
            return false;
        }
