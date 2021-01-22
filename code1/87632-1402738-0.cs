    List<Tender> list = new List<Tender>();
            foreach (TndCustomerTenders item in collection)
            {
                //assumes conversion via constructor
                list.Add(new Tender(item));
            }
