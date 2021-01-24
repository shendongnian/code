    public interface IDataService {
        //...expose desired members
    }
    
    public class DataService: IDataService {
        private readonly ApplicationDbContext context;
    
        public DataService(ApplicationDbContext context) {
            this.context = context;
        }
    
        //...other members implemented
    }
