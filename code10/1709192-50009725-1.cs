        public string ReturnGoodPeopleJsonFormat()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();//Needed for converting an object to Json string.
            List<PersonDataTable> personDataTableList = new List<PersonDataTable>();//Needed for filling your data from in program or from database
            List<Person> personList = new List<Person>();//Needed 'to be converted' in to Json string
            //Add items to your DataTable list manually
            personDataTableList.Add(
                new PersonDataTable { Pers_Id = 1, Pers_First_Name = "ABC", Pers_Last_Name = "Ln", Pers_Update = Convert.ToDateTime("2018-03-25"), OrderId = 1, OrderNu = 76454 });
            personDataTableList.Add(
                new PersonDataTable { Pers_Id = 1, Pers_First_Name = "ABC", Pers_Last_Name = "Ln", Pers_Update = Convert.ToDateTime("2018-03-25"), OrderId = 2, OrderNu = 76578 });
            //or from database
            // personDataTableList.AddRange(myDatabaseModel.DataTables.ToList());
            //Now group your data by Pers_Id //We are grouping this because we don't want same person 2 or 3 time, we want one person just one time but get all orders in it. That's why we need to group them by Pers_Id
            foreach (var personGroup in personDataTableList.GroupBy(x => x.Pers_Id))
            {
                List<Person.Order> orderList = new List<Person.Order>();
                foreach (var dataTablePerson in personDataTableList.Where(x => x.Pers_Id == personGroup.Key))
                {
                    //Get all orders of personGroup one by one in to an Order list from PersonDataTable list by using Pers_Id like a foreign key.
                    ///This personGroup.Key is nothing but Pers_Id\\\ 
                    orderList.Add(new Person.Order { OrderID = dataTablePerson.OrderId, OrderNu = dataTablePerson.OrderNu });
                }
                //Add new Person object to your personList if you don't have it before (by checking Pers_Id)
                if (personList.Where(x => x.Pers_Id == personGroup.Key).Count() == 0) //This personGroup.Key is nothing but Pers_Id
                {
                    personList.Add(new Person
                    {
                        Pers_Id = personDataTableList.Where(x => x.Pers_Id == personGroup.Key).FirstOrDefault().Pers_Id,
                        Pers_First_Name = personDataTableList.Where(x => x.Pers_Id == personGroup.Key).FirstOrDefault().Pers_First_Name,
                        Pers_Last_Name = personDataTableList.Where(x => x.Pers_Id == personGroup.Key).FirstOrDefault().Pers_Last_Name,
                        Pers_Update = personDataTableList.Where(x => x.Pers_Id == personGroup.Key).FirstOrDefault().Pers_Update,
                        Order_List = orderList
                    });
                }
            }
            string JsonString = js.Serialize(personList);
            return JsonString;
        }
