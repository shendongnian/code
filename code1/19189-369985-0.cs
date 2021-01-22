            testdbDataContext db = new testdbDataContext();
            Address a = new Address();
            db.GetTable(a.GetType()).Attach(a);
            a.Address1 = "simple change";
            var result = db.GetTable(a.GetType()).GetModifiedMembers(a);
            Console.WriteLine(result.Length);
            Console.ReadKey();
