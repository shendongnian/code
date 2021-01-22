    public class CEnumResult : CEnum
    {
      private   static List<CEnumResult>  ms_listoValue = new List<CEnumResult>();
      public    static readonly CEnumResult Nothing         = new CEnumResult (  0);
      public    static readonly CEnumResult SUCCESS         = new CEnumResult (  1);
      public    static readonly CEnumResult UserAbort       = new CEnumResult ( 11);
      public    static readonly CEnumResult InProgress      = new CEnumResult (101);
      public    static readonly CEnumResult Pausing         = new CEnumResult (201);
      private   static readonly CEnumResult Dummy           = new CEnumResult (msc_iUpdateNames);
      protected CEnumResult () : base ()
      {
      }
      protected CEnumResult (int i_iValue) : base (i_iValue)
      {
      }
      protected override void CommonConstructor (int i_iValue)
      {
        base.CommonConstructor (i_iValue);
        if (i_iValue == msc_iUpdateNames)
          return;
        if (this.GetType () == System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType)
          ms_listoValue.Add (this);
      }
      public static new CEnumResult[] GetValues ()
      {
        List<CEnumResult> listoValue = new List<CEnumResult> ();
        listoValue.AddRange (ms_listoValue);
        return listoValue.ToArray ();
      }
    }
    public class CEnumResultClassCommon : CEnumResult
    {
      private   static List<CEnumResultClassCommon> ms_listoValue = new List<CEnumResultClassCommon>();
      public    static readonly CEnumResult Error_InternalProgramming           = new CEnumResultClassCommon (1000);
      public    static readonly CEnumResult Error_Initialization                = new CEnumResultClassCommon ();
      public    static readonly CEnumResult Error_ObjectNotInitialized          = new CEnumResultClassCommon ();
      public    static readonly CEnumResult Error_DLLMissing                    = new CEnumResultClassCommon ();
      // ... many more
      private   static readonly CEnumResult Dummy                               = new CEnumResultClassCommon (msc_iUpdateNames);
      protected CEnumResultClassCommon () : base ()
      {
      }
      protected CEnumResultClassCommon (int i_iValue) : base (i_iValue)
      {
      }
      protected override void CommonConstructor (int i_iValue)
      {
        base.CommonConstructor (i_iValue);
        if (i_iValue == msc_iUpdateNames)
          return;
        if (this.GetType () == System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType)
          ms_listoValue.Add (this);
      }
      public static new CEnumResult[] GetValues ()
      {
        List<CEnumResult> listoValue = new List<CEnumResult> (CEnumResult.GetValues ());
        listoValue.AddRange (ms_listoValue);
        return listoValue.ToArray ();
      }
    }
