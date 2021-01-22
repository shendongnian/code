    static string ReadLettersAndDigits() {
        StringBuilder sb = new StringBuilder();
        ConsoleKeyInfo keyInfo;
        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter) {
            char c = char.ToLower(keyInfo.KeyChar);
            if (('a' <= c && c <= 'z') || char.IsDigit(c)) {
                sb.Append(keyInfo.KeyChar);
                Console.Write(c);
            }
        }
        return sb.ToString();
    }
