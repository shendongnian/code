      try
            {
      string json = File.ReadAllText(@"w:\code\csharp\JsonToXML\simple-sample.json").ToString();
                Accounts accs = JsonConvert.DeserializeObject<Accounts>(json);
                foreach (var acc in accs.account_list)
                {
                    Console.WriteLine(acc.id.ToString());
                    
                  
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
               throw ex;
            }
            Console.ReadKey();
        }
