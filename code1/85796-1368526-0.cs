    public class TestingRemoteDeviceManager : RemoteDeviceManager
    {
       public override IDbConnection CreateConnection()
       {
             IDbConnection conn = new Mock<IDbConnection>();
             //mock out the rest of the interface, as well as the IDbCommand and
             //IDataReader interfaces
             return conn;
       }
    }
