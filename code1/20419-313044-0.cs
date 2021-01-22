        // ...
        {
           //...
           MyCollection1 collection3 = GetCollectionFromDb<MyCollection1>(Collection1Name);
        }
        private static T GetCollectionFromDb<T>(string pCollectionName) where T : MyCollectionBase<T>
        {
            IList<T> queryResult = db.Query((T c) => c.CollectionName == pCollectionName);
            if (queryResult.Count != 0) return queryResult[0];
            return null;
        }
