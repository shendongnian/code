public int GetHashCode(DataRow obj)
{
    var values = obj.ItemArray.Except(new object[]{ obj[obj.Table.PrimaryKey[0].ColumnName] });
    int hash = 0;
    foreach (var value in values)
    {
        hash = (hash * 397) ^ value.GetHashCode();
    }
    return hash;
}
