        public void OrderManyTimes()
        {
            DataClasses1DataContext myDC = new DataClasses1DataContext();
            var query = myDC.Customers.OrderBy(c => c.Field3);
            query = query.OrderBy(c => c.Field2);
            query = query.OrderBy(c => c.Field1);
            Console.WriteLine(myDC.GetCommand(query).CommandText);
        }
