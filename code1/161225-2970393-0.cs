            DateTime rs1 = new DateTime(2010, 1, 1);
            DateTime re1 = new DateTime(2010, 2, 1);
            DateTime rs2 = new DateTime(2010, 1, 5);
            DateTime re2 = new DateTime(2010, 2, 5);
            TimeSpan d = new TimeSpan(Math.Max(Math.Min(re1.Ticks, re2.Ticks) - Math.Max(rs1.Ticks, rs2.Ticks) + TimeSpan.TicksPerDay, 0));
