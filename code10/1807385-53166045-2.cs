    struct SeqStruct
    {
        private uint _num;        
        public void Increment() => _num++;
    }
    // ----------------------------------
    var seq = new SeqStruct();
    var stopwatch = Stopwatch.StartNew();
    for (int i = 0; i < 100000000; i++)
        seq.Increment();
    s3.Stop();
