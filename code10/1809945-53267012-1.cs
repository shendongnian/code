    public class BusinessObject: IBusinessObject{
    
        private readonly IDataAccess dataAccess;
    
        public BusinessObject(IDataAccess dataAccess) {
            this.dataAccess = dataAccess;
        }
    
        public OutPutModel SomeBusinessMethod(InputModel1 obj1, InputModel2 obj2) {
            // Performing some actions here including seding a call
            // to the data access layer to perform some db operation.
            var outPutModel = dataAccess.SomeMethod(obj1, obj2);
    
            return outPutModel;
        }
    }
