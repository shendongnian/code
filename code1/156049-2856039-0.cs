    static DateTime[] ReadDates() {
      List<DateTime> result = new List<DateTime>();
      byte[] data = File.ReadAllBytes(appDataFile);
      for (int i = 0; i < data.Length; i += 8) {
        result.Add(new DateTime(BitConverter.ToInt64(data, i)));
      }
      return result;
    }
