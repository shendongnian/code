    //This is changed slightly from my actual code but it should give you an idea of what to do
    //tickStorage contains a dictionary named MessageData and the key is the column name
    //Obviously tickStorage is what is being directly mapped to my listView component
    
    private void OutputItems(StreamWriter writer, int startIndex, int endIndex, String delimiter)
    {
        endIndex = endIndex < tickStorage.Count ? endIndex : tickStorage.Count;
        for (Int32 i = startIndex; i < endIndex; i++)
        {
    	IEnumerator<Columns> fields = listView.ColumnsInDisplayOrder.GetEnumerator();
    	fields.MoveNext();
    	writer.Write((tickStorage[i].MessageData[fields.Current.Text]).Trim());
    	while (fields.MoveNext())
    	{
    	    writer.Write(delimiter + (tickStorage[i].MessageData[fields.Current.Text]).Trim());
    	}
    	writer.WriteLine();
        }
    }
