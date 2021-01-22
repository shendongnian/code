        static void Process()
        {
            double[] test = { 1, 2, 3, 4 };
            double[] answer = new double[test.Length];
            for (int i = 0; i &lt; test.Length; i++)
            {
                answer[i] = Math.Log(test[i]);
            }
        }
