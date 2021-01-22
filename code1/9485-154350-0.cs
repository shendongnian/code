public static IDictionary&lt;string, int&gt; ConvertEnumToDictionaryNameFirst&lt;K&gt;()
{
  if (typeof(K).BaseType != typeof(Enum))
  {
    throw new InvalidCastException();
  }
  return Enum.GetValues(typeof(K)).Cast&lt;int&gt;().ToDictionary(currentItem 
    => Enum.GetName(typeof(K), currentItem));
}
