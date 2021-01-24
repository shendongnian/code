    class ItemsRepository
    {
        public Item GetItem(string params)
        {
             ....
        }
    }
     var repo = new ItemsRepo();
     var item = repo.GetItem("params");
