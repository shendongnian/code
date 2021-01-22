    public bool HasData(TcpClient c, string terminator) {
      return HasData(c, (s) => s.Contains(terminator));
    }
    public bool HasData(TcpClient c, string t1, string t2) {
      return HasData(c, (s) => s.Contains(t1) || s.Contains(t2));
    }
