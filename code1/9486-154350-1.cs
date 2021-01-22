public static IDictionary&lt;int, string&gt; ConvertEnumToDictionaryValueFirst&lt;K&gt;()
{
  if (typeof(K).BaseType != typeof(Enum))
  {
    throw new InvalidCastException();
  }
  return Enum.GetNames(typeof(K)).Cast&lt;string&gt;().ToDictionary(currentItem 
    => (int)Enum.Parse(typeof(K), currentItem));
}
