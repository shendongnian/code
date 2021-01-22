    void Main()
    {
     Test t = new Test();
     var a = Enumerable.Range(1,10000000).Select(i => new  
     { 
      t.T0, t.T1, t.T2, t.T3, t.T4, t.T5, t.T6, t.T7, t.T8, t.T9,
      t.T10, t.T11, t.T12, t.T13, t.T14, t.T15, t.T16, t.T17, t.T18, t.T19,
      t.T20, t.T21, t.T22, t.T23, t.T24, t.T25, t.T26, t.T27, t.T28, t.T29,
      t.T30, t.T31, t.T32, t.T33, t.T34, t.T35, t.T36, t.T37, t.T38, t.T39,
     });
     
     Test2 t2 = new Test2();
     var b = Enumerable.Range(1,10000000).Select(i => new  
     { 
      t2.T0, t2.T1, t2.T2, t2.T3, t2.T4, t2.T5, t.T6, t2.T7, t2.T8, t2.T9,
      t2.T10, t2.T11, t2.T12, t2.T13, t2.T14, t2.T15, t2.T16, t2.T17, t2.T18, t2.T19,
      t2.T20, t2.T21, t2.T22, t2.T23, t2.T24, t2.T25, t2.T26, t2.T27, t2.T28, t2.T29,
      t2.T30, t2.T31, t2.T32, t2.T33, t2.T34, t2.T35, t2.T36, t2.T37, t2.T38, t2.T39,
     });
    
     a.Except(b).Dump();
    }
    
    class Test
    {
     public string T0 { get; set ;}
     public string T1 { get; set ;}
     public string T2 { get; set ;}
     public string T3 { get; set ;}
     public string T4 { get; set ;}
     public string T5 { get; set ;}
     public string T6 { get; set ;}
     public string T7 { get; set ;}
     public string T8 { get; set ;}
     public string T9 { get; set ;}
     public string T10 { get; set ;}
     public string T11 { get; set ;}
     public string T12 { get; set ;}
     public string T13 { get; set ;}
     public string T14 { get; set ;}
     public string T15 { get; set ;}
     public string T16 { get; set ;}
     public string T17 { get; set ;}
     public string T18 { get; set ;}
     public string T19 { get; set ;}
     public string T20 { get; set ;}
     public string T21 { get; set ;}
     public string T22 { get; set ;}
     public string T23 { get; set ;}
     public string T24 { get; set ;}
     public string T25 { get; set ;}
     public string T26 { get; set ;}
     public string T27 { get; set ;}
     public string T28 { get; set ;}
     public string T29 { get; set ;}
     public string T30 { get; set ;}
     public string T31 { get; set ;}
     public string T32 { get; set ;}
     public string T33 { get; set ;}
     public string T34 { get; set ;}
     public string T35 { get; set ;}
     public string T36 { get; set ;}
     public string T37 { get; set ;}
     public string T38 { get; set ;}
     public string T39 { get; set ;}
    }
    
    class Test2
    {
     public string T0 { get; set ;}
     public string T1 { get; set ;}
     public string T2 { get; set ;}
     public string T3 { get; set ;}
     public string T4 { get; set ;}
     public string T5 { get; set ;}
     public string T6 { get; set ;}
     public string T7 { get; set ;}
     public string T8 { get; set ;}
     public string T9 { get; set ;}
     public string T10 { get; set ;}
     public string T11 { get; set ;}
     public string T12 { get; set ;}
     public string T13 { get; set ;}
     public string T14 { get; set ;}
     public string T15 { get; set ;}
     public string T16 { get; set ;}
     public string T17 { get; set ;}
     public string T18 { get; set ;}
     public string T19 { get; set ;}
     public string T20 { get; set ;}
     public string T21 { get; set ;}
     public string T22 { get; set ;}
     public string T23 { get; set ;}
     public string T24 { get; set ;}
     public string T25 { get; set ;}
     public string T26 { get; set ;}
     public string T27 { get; set ;}
     public string T28 { get; set ;}
     public string T29 { get; set ;}
     public string T30 { get; set ;}
     public string T31 { get; set ;}
     public string T32 { get; set ;}
     public string T33 { get; set ;}
     public string T34 { get; set ;}
     public string T35 { get; set ;}
     public string T36 { get; set ;}
     public string T37 { get; set ;}
     public string T38 { get; set ;}
     public string T39 { get; set ;}
    }
