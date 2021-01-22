        [ReadUncommitedTransactionScope()]
        public static SomeEntities[] GetSomeEntities()
        {
            using (var context = new MyEntityConnection())
            {
                //any reads we do here will also read uncomitted data
                //...
                //...
                
            }
        }
