    namespace Test
    {
        class Generic<A, B>
        {
            public string Method(object a, object b)
            {
                if (a is A && b is B)
                    return MethodOneTwo;
                else if (a is B && b is A)
                    return MethodTwoOne;
                else
                    throw new ArgumentException("Invalid Types");
            }
            private string MethodOneTwo(A a, B b)
            {
                return a.ToString() + b.ToString();
            }
            private string MethodTwoOne(B b, A a)
            {
                return b.ToString() + a.ToString();
            }
        }
    }
