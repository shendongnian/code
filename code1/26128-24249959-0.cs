    public class DogOwnerMapOverride : IAutoMappingOverride<DogOwner>
    {
        public void Override( AutoMapping<DogOwner> mapping )
        {
            mapping.References( x => x.OwnedAnimal ).Not.LazyLoad();
        }
    }
