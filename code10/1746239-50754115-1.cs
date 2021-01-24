    class OriginSet {
      public string OriginType { get; set; }
      public Origin OriginData_A { get; set; }
      public Origin OriginData_B { get; set; }
      public Origin OriginData_C { get; set; }
      public bool? originA_State { get; set; }
      public bool? originB_State { get; set; }
      public bool? originC_State { get; set; }
      public OriginSet(string originType, Origin originDataA, Origin originDataB, Origin originDataC) {
        OriginType = originType;
        OriginData_A = originDataA;
        OriginData_B = originDataB;
        OriginData_C = originDataC;
        originA_State = originDataA.CheckState;
        originB_State = originDataB.CheckState;
        originC_State = originDataC.CheckState;
      }
