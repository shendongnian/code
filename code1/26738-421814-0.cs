string s = "sxrdct?fvzguh,bij.";
var sb = new StringBuilder();
foreach (char c in s)
{
   if (!char.IsPunctuation(c))
      sb.Append(c);
}
s = sb.ToString();
