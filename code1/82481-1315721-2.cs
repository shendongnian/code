        private void button1_Click(object sender, EventArgs e)
        {
            m_timer = new Timer(DoWork);
            m_timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(10));
        }
        private static void DoWork(object state)
        {
            long j = 0;
            for (int i = 0; i < 2000000; i++)
            {
                j += 1;
            }
            Console.WriteLine(j);
        }
