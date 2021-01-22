java
    static void Main(string[] args) {
            int[] vargu = { 16, 32, 40, 48, 56, 72 };
            int mbetja;
            for (int i = 0; i < vargu.Length; i++)
            {
                mbetja = vargu[i] * 2 % (10 - 1);
                Console.Write(mbetja + " ");
            }
            int[] vargu1 = { 16, 48, 40, 32, 5, 7 };
            int[] vargu2 = { 48, 32, 16, 40, 56, 72,16,16,16,16,16,5,7,6,56};
            int k = 0;
            for (int i = 0; i < vargu1.Length; i++)
            {
                
                for (int j = 0; j < vargu2.Length; j++)
                {
                   
                    if (vargu1[i] == vargu2[j])
                    {
                        k++;
                        break;
                    }
                  
                }
                
            }
            if ( vargu1.Length == k)
            {
                Console.WriteLine(true);
            }
            else
                Console.WriteLine(false);
