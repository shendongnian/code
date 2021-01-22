public static byte[] ToBytes(string value)
{
  if (value == null) return null;
  return System.Text.Encoding.Unicode.GetBytes(value);
}
