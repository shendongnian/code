        [HttpGet]
        [Route("api/Fruits/thefruits")]
         public List<Fruits> TheFruits()
        {
            var myList = db.Fruits;
            var FiveItems = myList.AsEnumerable().Skip(1).Take(5).ToList();
            return FiveItems;
        }
