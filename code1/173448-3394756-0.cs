    [Serializable]
    [CollectionDataContract]
    public class TablesCollection : KeyedCollection<string, cTable>
    {
        protected override string GetKeyForItem(cTable item)
        {
            return item == null ? String.Empty : item.TableName;
        } 
    }
