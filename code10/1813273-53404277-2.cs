    static void Main(string[] args)
            {
                Auth();
                var result = CreateTable().Result;
                Console.WriteLine(result);
                Console.ReadKey();
            }
    async static Task<string> CreateTable()
    {
          CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
          CloudTable peopleTable = tableClient.GetTableReference("XYZ");
          try
             {
                    await peopleTable.CreateIfNotExistsAsync();
                    People customer = new People("Garry", "Johnson");
                    customer.Email = "xxx@yyy.zzz";
                    customer.PhoneNumber = "123456789";
                    TableOperation insertOperation = TableOperation.Insert(customer);
                    var result = await peopleTable.ExecuteAsync(insertOperation);
                    return result.HttpStatusCode.ToString();
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }
            return null;
               
      }
