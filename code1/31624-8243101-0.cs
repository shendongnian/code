    public class SpaceLocationMap : ClassMap<SpaceLocation>
    {
        public SpaceLocationMap()
        {
            CompositeId(x => x.Coordinates)
                .KeyProperty(x => x.x)
                .KeyProperty(x => x.y)
                .KeyProperty(x => x.z);
            References(x => x.AtLocation);
        }
    }
