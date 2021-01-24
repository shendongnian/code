    public class PlayerNameComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x.Name.CompareTo(y.Name) < 0)
                return -1;
            else if (x.Name.CompareTo(y.Name) == 0)
                return x.LastName.CompareTo(y.LastName);
            else
                return 1;
        }
    }
