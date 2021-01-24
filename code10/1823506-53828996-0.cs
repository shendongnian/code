    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        List<Product> GetProducts(); }
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Price { get; set; }
        public Product(int id, string name, int price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        } }
    public class Service1 : IService1
    {
    
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DataStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = new SqlCommand("select * from Products", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product(reader.GetInt32((reader.GetOrdinal("Id"))), reader.GetString(reader.GetOrdinal("Name")), reader.GetInt32(reader.GetOrdinal("Price"))));
            }
            reader.Close();
            connection.Close();
    
            return products;
        }
    }
