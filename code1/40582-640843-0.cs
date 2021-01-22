PropertyCollection collection = GetTheCollection();
foreach ( PropertyValueCollection value in collection ) {
  // Do something with the value
  Console.WriteLine(value.PropertyName);
  Console.WriteLine(value.Value);
  Console.WriteLine(value.Count);
}
