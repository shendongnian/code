    private class Service1ClientChannel : ChannelBase<IService1>, IService1
    {
        public Service1ClientChannel(System.ServiceModel.ClientBase<IService1> client) :
           base(client)
        {
        }
        public IAsyncResult BeginCheckIfUserExists(CheckIfUserExistsRequest request, AsyncCallback callback, object asyncState)
        {
            object[] _args = new object[1];
            _args[0] = request;
            return (IAsyncResult)base.BeginInvoke("CheckIfUserExists", _args, callback, asyncState);
        }
        public IAsyncResult BeginCheckIfUserNameExists(CheckIfUserNameExistsRequest request, AsyncCallback callback, object asyncState)
        {
            object[] _args = new object[1];
            _args[0] = request;
            return (IAsyncResult)base.BeginInvoke("CheckIfUserNameExists", _args, callback, asyncState);
        }
        public IAsyncResult BeginCreateUser(CreateUserRequest request, AsyncCallback callback, object asyncState)
        {
            object[] _args = new object[1];
            _args[0] = request;
            return (IAsyncResult)base.BeginInvoke("CreateUser", _args, callback, asyncState);
        }
        public IAsyncResult BeginGetDsImageAndID(GetDsImageAndIDRequest request, AsyncCallback callback, object asyncState)
        {
            object[] _args = new object[1];
            _args[0] = request;
            return (IAsyncResult)base.BeginInvoke("GetDsImageAndID", _args, callback, asyncState);
        }
        public IAsyncResult BeginGetDsItemInfo(GetDsItemInfoRequest request, AsyncCallback callback, object asyncState)
        {
            object[] _args = new object[1];
            _args[0] = request;
            return (IAsyncResult)base.BeginInvoke("GetDsItemInfo", _args, callback, asyncState);
        }
        public IAsyncResult BeginGetImageByteStream(int zipCode, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }
        public CheckIfUserExistsResponse CheckIfUserExists(CheckIfUserExistsRequest request)
        {
            throw new NotImplementedException();
        }
        public CheckIfUserNameExistsResponse CheckIfUserNameExists(CheckIfUserNameExistsRequest request)
        {
            throw new NotImplementedException();
        }
        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
        public CheckIfUserExistsResponse EndCheckIfUserExists(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        public CheckIfUserNameExistsResponse EndCheckIfUserNameExists(IAsyncResult result)
        {
            object[] _args = new object[0];
            return (CheckIfUserNameExistsResponse)base.EndInvoke("CheckIfUserNameExists", _args, result);
            //return Service1Client.
        }
        public CreateUserResponse EndCreateUser(IAsyncResult result)
        {
            object[] _args = new object[0];
            return (CreateUserResponse)base.EndInvoke("CreateUser", _args, result);
        }
        public GetDsImageAndIDResponse EndGetDsImageAndID(IAsyncResult result)
        {
            object[] _args = new object[0];
            return (GetDsImageAndIDResponse)base.EndInvoke("GetDsImageAndID", _args, result);
        }
        public GetDsItemInfoResponse EndGetDsItemInfo(IAsyncResult result)
        {
            object[] _args = new object[0];
            return (GetDsItemInfoResponse)base.EndInvoke("GetDsItemInfo", _args, result);
        }
        public Stream EndGetImageByteStream(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        public GetDsImageAndIDResponse GetDsImageAndID(GetDsImageAndIDRequest request)
        {
            throw new NotImplementedException();
        }
        public GetDsItemInfoResponse GetDsItemInfo(GetDsItemInfoRequest request)
        {
            throw new NotImplementedException();
        }
        public Stream GetImageByteStream(int zipCode)
        {
            throw new NotImplementedException();
        }
    }
