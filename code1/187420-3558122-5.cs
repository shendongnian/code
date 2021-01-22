        static void DataConcierge_Saved(object sender, DataObjectEventArgs<Program.Customer> e)
        {
            Console.WriteLine("DataConcierge<Customer>.Saved");
        }
        static void DataConcierge_BatchSaved(object sender, BatchDataObjectEventArgs<Program.Customer> e)
        {
            Console.WriteLine("DataConcierge<Customer>.BatchSaved: {0}", e.DataObjects.Count());
        }
        static void Main(string[] args)
        {
            DataConcierge<Customer> dc = new DataConcierge<Customer>();
            dc.Saved += new DataObjectSaved<Customer>(DataConcierge_Saved);
            dc.BatchSaved += new BatchDataObjectSaved<Customer>(DataConcierge_BatchSaved);
            var token = dc.BeginSave();
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    var c = new Customer();
                    // ...
                    dc.Save(token, c);
                }
            }
            finally
            {
                dc.EndSave(token);
            }
        }
