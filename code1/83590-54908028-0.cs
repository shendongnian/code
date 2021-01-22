namespace System.Runtime.Serialization
{
  public static class SerializationInfoExtensions
  {
    public static bool Exists(this SerializationInfo info, string name)
    {
      foreach (SerializationEntry entry in info)
        if (name == entry.Name)
          return true;
      return false;
    }
  }
}
