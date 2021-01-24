        static int max(int a, int b) 
        { 
            return (a > b)? a : b; 
        } 
          
        // Driver code 
        public static void Main() 
        { 
              
            String s1 = "giorgi"; 
            String s2 = "grigol"; 
          
            char[] X=s1.ToCharArray(); 
            char[] Y=s2.ToCharArray(); 
            int m = X.Length; 
            int n = Y.Length; 
          
            Console.Write("Length of LCS is" + " " +lcs( X, Y, m, n ) ); 
        } 
    } 
