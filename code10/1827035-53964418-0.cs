    public interface IPhotoService { 
         Photo CreatePhoto(params);
    }
    public interface IType1PhotoService : IPhotoService { }
    public interface IType2PhotoService : IPhotoService { }
    public interface IType3PhotoService : IPhotoService { }
    public class PhotoServiceFactory {
        private readonly IPhotoService _type1;
        private readonly IPhotoService _type2;
        private readonly IPhotoService _type3;
        public PhotoServiceFactory(IType1PhotoService type1Service, IType2PhotoService type2Service, IType3PhotoService type3PhotoService) {
            _type1 = type1Service;
            _type2 = type2Service;
            _type3 = type3Service;
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
