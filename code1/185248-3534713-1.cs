        public static string Strip(this string phoneNumber)
        {
            return new string(
                new[]
                    {
                     // phoneNumber[0],     (
                        phoneNumber[1],  // 6
                        phoneNumber[2],  // 1
                        phoneNumber[3],  // 7
                     // phoneNumber[4],     )
                     // phoneNumber[5],   
                        phoneNumber[6],  // 8
                        phoneNumber[7],  // 6
                        phoneNumber[8],  // 7
                     // phoneNumber[9],     -
                        phoneNumber[10], // 5
                        phoneNumber[11], // 3
                        phoneNumber[12], // 0
                        phoneNumber[13]  // 9
                    });
        }
