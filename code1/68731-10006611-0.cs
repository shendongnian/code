    IEnumerable<object> getRecordsList()
        {
            using (var dbObj = new OrderEntryDbEntities())
            {
                return (from orderRec in dbObj.structSTIOrderUpdateTbls
                        select orderRec).ToList<object>();
            }
        }
