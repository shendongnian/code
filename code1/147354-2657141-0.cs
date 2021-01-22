    public class TrackLog {
       [Property]
       public string Name { get; set; }
       [HasMany(DependentObjects = true)]
       public ISet<TrackPoint> TrackPoints { get; set; }
    }
