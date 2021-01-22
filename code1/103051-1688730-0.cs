<PRE>
IsGuid implemented as extension method for string...
public static bool IsGuid(this string stringValue)
{
  string guidPattern = @"[a-fA-F0-9]{8}(\-[a-fA-F0-9]{4}){3}\-[a-fA-F0-9]{12}";
  if(string.IsNullOrEmpty(stringValue))
    return false;
  Regex guidPattern = new Regex(guidPattern);
  return guidPattern.IsMatch(stringValue);
}
</PRE>
