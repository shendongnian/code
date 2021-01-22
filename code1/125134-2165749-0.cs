    struct S { 
        public int x; 
        public override string ToString() { return "Hello!" + x; } 
    }
    ...
    S s = new S();
    s.x = 0x00112233;
    s.ToString();
