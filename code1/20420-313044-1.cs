        private static MyCollection1 GetCollectionFromDb<MyCollection1>(string pCollectionName) where T : MyCollectionBase< MyCollection1 >
        {
            IList< MyCollection1 > queryResult = db.Query((MyCollection1 c) => c.CollectionName == pCollectionName);
            if (queryResult.Count != 0) return queryResult[0];
            return null;
        }
