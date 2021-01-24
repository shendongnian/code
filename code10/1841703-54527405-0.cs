byte[] image;
foreach (KeyValuePair<string, byte[]> val in input.Collection)
{
    image = val.Value;
    // Then do something with 'image', like: System.IO.File.WriteAllBytes($"C:\\MyImage_{val.Key}.jpg", image);
}
