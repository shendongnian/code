        [ServiceContract]
        public interface IAuthenticationService
        {
           [OperationContract]
           ClientInfo ChangeSessionUser(User user);
           [OperationContract]
           ClientInfo GetSessionUserInfo();
           [FaultContract(typeof(ServiceFault))]
           [OperationContract]
           ClientInfo Login(LoginCredentials credentials);
           [OperationContract]
           void Logout(string id);
           [FaultContract(typeof(ServiceFault))]
           [OperationContract]
           void RemoveInvalidUserLogins();
           [OperationContract]
           void RemoveSesseionFromCache(string id);
           [FaultContract(typeof(ServiceFault))]
           [OperationContract]
           bool ValidateUser(LoginCredentials credentials);
        }
