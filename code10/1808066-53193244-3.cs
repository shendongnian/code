        static String ReturnOdd(int[] tab)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in tab)
            {
                if (i % 2 == 1)
                    sb.Append($"{i},");
            }
            return sb.ToString().TrimEnd(',');
        }
