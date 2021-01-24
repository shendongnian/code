    public class AuthMathematics : IAuthMathematics
    {
        public AuthMathematics(int a, int b) {
            A = a;
            B = b;
        }
    
        public int A { get; private set; }
        public int B { get; private set; }
        int IAuthMathematics.Sum() { return A + B; }
    }
