            string actualString = "1111222233334444";
            var listResult = new List<string>();
            int groupingLength = actualString.Length % 4;
            if (groupingLength > 0)
                listResult.Add(actualString.Substring(0, groupingLength));
            for (int i = groupingLength; i < actualString.Length; i += 4)
            {
                listResult.Add(actualString.Substring(i, 4));
            }
            foreach(var res in listResult)
            {
                Console.WriteLine(res);
            }
            Console.Read();
