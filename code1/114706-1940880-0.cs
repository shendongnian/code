       public IEnumerable<string> readColors()
        {
            try
            {
                string[] colors = { "red", "green", "blue" };
                for (int i = 0; i < colors.Length; i++)
                    yield return colors[i];
            }
            finally
            {
                Console.WriteLine("Cleanup goes here");
            }
        }
