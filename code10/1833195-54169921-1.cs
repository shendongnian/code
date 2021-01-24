        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Node1 != null ? Node1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Port1.GetHashCode();
                hashCode = (hashCode * 397) ^ (Node2 != null ? Node2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Port2.GetHashCode();
                hashCode = (hashCode * 397) ^ Working.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxBandwidth;
                return hashCode;
            }
        }
