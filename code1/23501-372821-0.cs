    using System;
    using System.Threading;
    using System.Diagnostics;
    namespace ThreadTest
    {
        class Program
        {
            struct SmallMatrix
            {
                double m_a, m_b, m_c, m_d;
                public SmallMatrix(double x)
                {
                    m_a = x;
                    m_b = x;
                    m_c = x;
                    m_d = x;
                }
                public static bool SameValueEverywhere(SmallMatrix m)
                {
                    return (m.m_a == m.m_b)
                        && (m.m_a == m.m_c)
                        && (m.m_a == m.m_d);
                }
            }
            static SmallMatrix s_smallMatrix;
            static void Watcher()
            {
                while (true)
                    Debug.Assert(SmallMatrix.SameValueEverywhere(s_smallMatrix));
            }
            static void Main(string[] args)
            {
                (new Thread(Watcher)).Start();
                while (true)
                {
                    s_smallMatrix = new SmallMatrix(0);
                    s_smallMatrix = new SmallMatrix(1);
                }
            }
        }
    }
