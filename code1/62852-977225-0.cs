    public void SaveCollection<T>(IEnumerable<T> collection)
        where T : ITableDescriptor
    {
        foreach (T element in collection)
        {
            string tableFieldName = element.TableFieldName;
            // use the table field name here
        }
    }
