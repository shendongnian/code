var values = new[] { "", "1", "2", "a", "3" };
List<int> numeric_list = new List<int>();
foreach (string string_value in values)
{
    try
    {
        numeric_list.Add(Convert.ToInt32(string_value));
    }
    catch (Exception)
    {
        // Do nothing, since we want to skip.
    }
}
return numeric_list.ToArray();
