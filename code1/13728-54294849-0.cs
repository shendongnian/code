    public class VidMark : IMyCloneable<VidMark>
    {
        public long Beg { get; set; }
        public long End { get; set; }
        public string Desc { get; set; }
        public int Rank { get; set; } = 0;
        public VidMark Clone()
        {
            return (VidMark)this.MemberwiseClone();
        }
    }
