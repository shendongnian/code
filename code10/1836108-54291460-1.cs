    public class PhotoPlace
    {
        public long Id { get; set; }
        ... // other properties
        // every PhotoPlace has zero or more ParkingLocations (one-to-many)
        public virtual ICollection<ParkingLocation> ParkingLocations { get; set; }
    }
    public class ParkingLocation
    {
        public long Id {get; set;}
        ...
        // every ParkingLocation belongs to exactly one PhotoPlace using foreign key
        public long PhotoPlaceId {get; set;}
        public virtual PhotoPlace PhotoPlace {get; set;}
        // every ParkingLocation has zero or more ShootingLocations (one-to-many)
        public virtual ICollection<ShootingLocation> ShootingLocations {get; set;}
    }
