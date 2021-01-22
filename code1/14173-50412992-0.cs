    static void Reverse()
        {
            string str = "PankajRawat";
            var arr = str.ToCharArray();
            for (int i = str.Length-1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }
        }
