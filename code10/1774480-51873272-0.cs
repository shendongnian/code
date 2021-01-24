        [Test]
        public void test_compare_twolistsforchanges()
        {
            List<Deal> newDeals = new List<Deal>()
            {
                new Deal { Id = 10, Name = "Bank of America Deal Has Changed", Description = "Pay Bill"},
                new Deal { Id = 11, Name = "Bank of America11", Description = "Pay Bill"},
                new Deal { Id = 12, Name = "Bank of America12-12", Description = "Pay Bill"},
            };
            List<Deal> oldDeals = new List<Deal>
            {
                new Deal { Id = 10, Name = "Bank of America", Description = "Pay Bill"},
                new Deal { Id = 11, Name = "Bank of America11", Description = "Pay Bill"},
                new Deal { Id = 12, Name = "Bank of America12", Description = "Pay Bill"},
                new Deal { Id = 13, Name = "Bank of America13", Description = "Pay Bill"},
                new Deal { Id = 14, Name = "Bank of America14", Description = "Pay Bill"}
            };
            // Using Linq to detech a change
            var result = newDeals.Where(nd => oldDeals.Where(od => od.Id == nd.Id).Any(od => od.HashValues() != nd.HashValues()));
            System.Diagnostics.Debug.WriteLine("Changed => " + result.Count());
            System.Diagnostics.Debug.WriteLine(string.Join(Environment.NewLine, result.Select(x => x.Id)));
           
        }
        internal class Deal
        {
            private static System.Security.Cryptography.MD5CryptoServiceProvider hashPRovider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            internal Deal() { }
            internal int Id { get; set; }
            internal string Name { get; set; }
            internal string Description { get; set; }
            internal Guid HashValues()
            {
                byte[] inputBytes = Encoding.Default.GetBytes(string.Join("", this.Name, this.Description));
                byte[] hashBytes = hashPRovider.ComputeHash(inputBytes);
                Guid hashGuid = new Guid(hashBytes);
                return hashGuid;
            }
            
        }
