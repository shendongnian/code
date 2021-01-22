            dynamic sa = DataStore.GetHistory(DateTime.Now, "satish");
            foreach (var a in sa)
            {
                Console.WriteLine(a.ConvText);
            }
