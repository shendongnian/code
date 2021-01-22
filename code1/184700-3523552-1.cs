var values = new[] { "", "1", "2", "a", "3" };
List<int> numeric_list = new List<int>();
int num_try = 0;
foreach (string string_value in values)
{
    if (Int32.TryParse(string_value.ToString(), out num_try) {
        numeric_list.Add(num_try);
    }
    /* BAD PRACTICE (as noted by other StackOverflow users)
    try
    {
        numeric_list.Add(Convert.ToInt32(string_value));
    }
    catch (Exception)
    {
        // Do nothing, since we want to skip.
    }
    */
}
return numeric_list.ToArray();
