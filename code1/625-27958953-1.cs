    public static class HumanFriendlyInteger
    {
        static string[] ones = new string[] { "", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
        static string[] teens = new string[] { "On", "On Bir", "On İki", "On Üç", "On Dört", "On Beş", "On Altı", "On Yedi", "On Sekiz", "On Dokuz" };
        static string[] tens = new string[] { "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };
        static string[] thousandsGroups = { "", " Bin", " Milyon", " Milyar" };
        private static string FriendlyInteger(int n, string leftDigits, int thousands)
        {
            if (n == 0)
            {
                return leftDigits;
            }
            string friendlyInt = leftDigits;
            if (friendlyInt.Length > 0)
            {
                friendlyInt += " ";
            }
            if (n < 10)
                friendlyInt += ones[n];
            else if (n < 20)
                friendlyInt += teens[n - 10];
            else if (n < 100)
                friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
            else if (n < 1000)
                friendlyInt += FriendlyInteger(n % 100, ((n / 100 == 1 ? "" : ones[n / 100] + " ") + "Yüz"), 0); // Yüz 1 ile başlangıçta "Bir" kelimesini Türkçe'de almaz.
            else
                friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);
            return friendlyInt + thousandsGroups[thousands];
        }
        public static string IntegerToWritten(int n)
        {
            if (n == 0)
                return "Sıfır";
            else if (n < 0)
                return "Eksi " + IntegerToWritten(-n);
            return FriendlyInteger(n, "", 0);
        }
