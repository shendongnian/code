    class Range {
       int Lower { get; set; }
       int Upper { get; set; }
    }
    List<Range>.FirstOrDefault(r => i >= r.Lower && i <= r.Upper);
