    public class Node<T> 
    {
        public double Speed { get; }
        public double Time { get; }
        public double Distance { get; }
        public T Source { get; }
        public T Destination { get; }
        public Node(T source, T destination, double speed, double distance)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (Math.Abs(speed) < 1E-9) throw new ArgumentException("speed must greater than zero", nameof(speed));
            if (Math.Abs(distance) < 1E-9) throw new ArgumentException("distance must greater than zero", nameof(speed));
            Source = source;
            Destination = destination;
            Speed = speed;
            Distance = distance;
            Time = Distance / Speed;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Node<T> objAsNodeT))
            {
                return false;
            }
            return Math.Abs(Speed - objAsNodeT.Speed) < 1E-9
                   && Math.Abs(Time - objAsNodeT.Time) < 1E-9
                   && Source.Equals(objAsNodeT.Source)
                   && Destination.Equals(objAsNodeT.Destination);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash*7) + Speed.GetHashCode();
                hash = (hash*7) + Time.GetHashCode();
                hash = (hash*7) + Source.GetHashCode();
                hash = (hash*7) + Destination.GetHashCode();
                return hash;
            }
        }
    }
