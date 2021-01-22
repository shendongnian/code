public static List&lt;T> GetMyList&lt;T>(T[] itemList)
{
  List<T> resultList = new List<T>(itemList.Length);
  foreach (t in itemList)
  {
    resultList.add(t);
  }
  return resultList;
}
