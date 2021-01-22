foreach (PropertyInfo property in obj.GetType().GetProperties())
{
  object value = property.GetValue(obj, null);
  if (value is object[])
  {
    ....
  }
}
