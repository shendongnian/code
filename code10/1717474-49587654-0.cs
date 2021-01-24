    public class CustomResolver : IValueResolver<ProductType, ViewModelProductType, IList<ViewModelProductIdentifier>>
    {
        public int Resolve(ProductType source, ViewModelProductType destination, IList<ViewModelProductIdentifier> destMember, ResolutionContext context)
        {
            // Map you source collection to the destination list here and return it
        }
    }
