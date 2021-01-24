    public class MService: IMService {
    
        private readonly IMRepository mRepository;
    
        public MService(IMRepository mRepository) {
            this.mRepository = mRepository;
        }
    
        public List<FUser> GetFUser() {
            var result = mRepository.ExecuteCommandReader();
            return result
        }
    }
