    using System.Linq;
    ...
    string[] hexValues = new string[] {
      "10", "0F", "3E", "42"};
    byte[] result = hexValues
      .Select(value => Convert.ToByte(value, 16))
      .ToArray();
