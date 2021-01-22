        public static Guid ToSeqGuid()
        {
            Int64 lastTicks = -1;
            long ticks = System.DateTime.UtcNow.Ticks;
            if (ticks <= lastTicks)
            {
                ticks = lastTicks + 1;
            }
            lastTicks = ticks;
            byte[] ticksBytes = BitConverter.GetBytes(ticks);
            Array.Reverse(ticksBytes);
            Guid myGuid = new Guid();
            byte[] guidBytes = myGuid.ToByteArray();
            Array.Copy(ticksBytes, 0, guidBytes, 10, 6);
            Array.Copy(ticksBytes, 6, guidBytes, 8, 2);
            Guid newGuid = new Guid(guidBytes);
            string filepath = @"C:\temp\TheNewGuids.txt";
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine("GUID Created =  " + newGuid.ToString());
            }
            return newGuid;
        }
    }
}
