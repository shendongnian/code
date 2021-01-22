        static void Main(string[] args)
        {
            for (int i=0; i < 10; i++)
            {
                var j = testMethod();
                if (j == null)
                {
                    System.Diagnostics.Debug.WriteLine("j is null");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(j.GetType().ToString());
                }
            }
        }
        static int? testMethod()
        {
            int rem;
            Math.DivRem(Convert.ToInt32(DateTime.Now.Millisecond), 2, out rem);
            if (rem > 0)
            {
                return rem;
            }
            else
            {
                return null;
            }
        }
