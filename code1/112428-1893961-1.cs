    Diff GetDiff(byte[] a, byte[] b)
    {
        Diff diff = new Diff();
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                diff.Points.Add(new DiffPoint(i, a[i]));
            }
        }
        return diff;
    }
    // Mutator method - turns "b" into the original "a"
    void ApplyDiff(byte[] b, Diff diff)
    {
        foreach (DiffPoint point in diff.Points)
        {
            b[point.Index] = point.Value;
        }
    }
    // Copy method - recreates "a" leaving "b" intact
    byte[] ApplyDiffCopy(byte[] b, Diff diff)
    {
        byte[] a = new byte[b.Length];
        int startIndex = 0;
        foreach (DffPoint point in diff.Points)
        {
            for (int i = startIndex; i < point.Index; i++)
            {
                a[i] = b[i];
            }
            a[point.Index] = point.Value;
            startIndex = point.Index + 1;
        }
        for (int j = startIndex; j < b.Length; j++)
        {
            a[j] = b[j];
        }
        return a;
    }
    struct DiffPoint
    {
        public int Index;
        public byte Value;
        public DiffPoint(int index, byte value) : this()
        {
            this.Index = index;
            this.Value = value;
        }
    }
    class Diff
    {
        public Diff()
        {
            Points = new List<DiffPoint>();
        }
        public List<DiffPoint> Points { get; private set; }
    }
