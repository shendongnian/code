    static public String MemoryDisplay(byte[] mem)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < mem.Length; i += 32)
        {
            var line = mem.Skip(i).Take(32).ToArray();
            sb.AppendFormat("{0:x8} {1,-96}{2}" + Environment.NewLine,
                i,
                String.Join(" ", line.Select(e => e.ToString("x2")).ToArray()),
                new String(line.Select(e => 32 <= e && e <= 127 ? (Char)e : '.').ToArray()));
        }
        return sb.ToString();
    }
