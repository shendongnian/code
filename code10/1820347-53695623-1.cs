            string[] charList =
            {
                "abcdefghijklmnopqrstuvwxyz",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789",
                "@\"!#$%&*@\\"
            };
            int desiredPasswordLength = 12;
            var randomNumberGenerator = new Random();
            string generatedPassword = "";
            for (int i = randomNumberGenerator.Next() % 4; desiredPasswordLength > 0; i = (i+1) % 4)
            {
                var randomChar = randomNumberGenerator.Next() % charList[i].Length;
                char selectedChar = charList[i][randomChar % charList[i].Length];
                generatedPassword = string.Join("", generatedPassword, selectedChar);
                desiredPasswordLength --;
            }
            Console.WriteLine("Generated password: {0}",generatedPassword);
