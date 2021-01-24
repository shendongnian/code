    // read size (4) digits
    private static string ReadPin(int size = 4) {
      StringBuilder sb = new StringBuilder(size);
      while (sb.Length < size) {
        var key = Console.ReadKey(true); // we don't want to show the secret pin on the screen
        if (key.KeyChar >= '0' && key.KeyChar <= '9') {
          sb.Append(key.KeyChar);
          Console.Write('*'); // let's show * instead of actual digit
        }
      }
      return sb.ToString();
    }
    ...
    // private: there's no need for Main to be public
    private static void Main() {
      ...
      Console.WriteLine("Enter Your Pin Number ");
      int pin = int.Parse(ReadPin());
