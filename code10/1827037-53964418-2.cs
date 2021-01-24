    public interface IPhotoService { 
         Photo CreatePhoto(params);
    }
    public class PhotoServiceFactory {
        private readonly IPhotoService _type1;
        private readonly IPhotoService _type2;
        private readonly IPhotoService _type3;
        public PhotoServiceFactory(IDependency1 d1, IDependency2 d2, ...etc) {
            _type1 = new ConcreteServiceA(d1);
            _type2 = new ConcreteServiceB(d2);
            _type3 = new ConcreteServiceC(etc);
        }
        public IPhotoService Create(User user) {
            switch(user.Claim) {
                case ClaimEnum.Type1:
                    return _type1;
                case ClaimEnum.Type2:
                    return _type2;
                case ClaimEnum.Type3:
                    return _type3;
                default:
                    throw new NotImplementedException
            }
        }
    }
