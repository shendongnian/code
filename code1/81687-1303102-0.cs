        class TestGetHash
        {
            class First
            {
                int m_x;
            }
            class Second
            {
                static int s_allocated = 0;
                int m_allocated;
                int m_x;
                public Second()
                {
                    m_allocated = ++s_allocated;
                }
                public override int GetHashCode()
                {
                    return m_allocated;
                }
            }
            class Third
            {
                int m_x;
                public override int GetHashCode()
                {
                    return 0;
                }
            }
            internal static void test()
            {
                testT<First>(100, 1000);
                testT<First>(1000, 100);
                testT<Second>(100, 1000);
                testT<Second>(1000, 100);
                testT<Third>(100, 100);
                testT<Third>(1000, 10);
            }
            static void testT<T>(int objects, int iterations)
                where T : new()
            {
                System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < iterations; ++i)
                {
                    Dictionary<T, object> dictionary = new Dictionary<T, object>();
                    for (int j = 0; j < objects; ++j)
                    {
                        T t = new T();
                        dictionary.Add(t, null);
                    }
                    for (int k = 0; k < 100; ++k)
                    {
                        foreach (T t in dictionary.Keys)
                        {
                            object o = dictionary[t];
                        }
                    }
                }
                stopWatch.Stop();
                string stopwatchMessage = string.Format("Stopwatch: {0} type, {1} objects, {2} iterations, {3} msec", typeof(T).Name, objects, iterations, stopWatch.ElapsedMilliseconds);
                System.Console.WriteLine(stopwatchMessage);
                stopWatch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < iterations; ++i)
                {
                    Dictionary<T, object> dictionary = new Dictionary<T, object>();
                    for (int j = 0; j < objects; ++j)
                    {
                        T t = new T();
                        dictionary.Add(t, null);
                    }
                }
                stopWatch.Stop();
                stopwatchMessage = string.Format("Stopwatch (fill dictionary): {0} type, {1} objects, {2} iterations, {3} msec", typeof(T).Name, objects, iterations, stopWatch.ElapsedMilliseconds);
                System.Console.WriteLine(stopwatchMessage);
                {
                    Dictionary<T, object> dictionary = new Dictionary<T, object>();
                    for (int j = 0; j < objects; ++j)
                    {
                        T t = new T();
                        dictionary.Add(t, null);
                    }
                    stopWatch = System.Diagnostics.Stopwatch.StartNew();
                    for (int i = 0; i < iterations; ++i)
                    {
                        for (int k = 0; k < 100; ++k)
                        {
                            foreach (T t in dictionary.Keys)
                            {
                                object o = dictionary[t];
                            }
                        }
                    }
                    stopWatch.Stop();
                    stopwatchMessage = string.Format("Stopwatch (read from dictionary): {0} type, {1} objects, {2} iterations, {3} msec", typeof(T).Name, objects, iterations, stopWatch.ElapsedMilliseconds);
                    System.Console.WriteLine(stopwatchMessage);
                }
            }
        }
