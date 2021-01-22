    public class CEnum
    {
      protected static readonly int msc_iUpdateNames  = int.MinValue;
      protected static int          ms_iAutoValue     = -1;
      protected static List<int>    ms_listiValue     = new List<int>();
      public int Value
      {
        get;
        protected set;
      }
      public string Name
      {
        get;
        protected set;
      }
      protected CEnum ()
      {
        CommonConstructor (-1);
      }
      protected CEnum (int i_iValue)
      {
        CommonConstructor (i_iValue);
      }
      public static string[] GetNames (IList<CEnum> i_listoValue)
      {
        if (i_listoValue == null)
          return null;
        string[] asName = new string[i_listoValue.Count];
        for (int ixCnt = 0; ixCnt < asName.Length; ixCnt++)
          asName[ixCnt] = i_listoValue[ixCnt]?.Name;
        return asName;
      }
      public static CEnum[] GetValues ()
      {
        return new CEnum[0];
      }
      protected virtual void CommonConstructor (int i_iValue)
      {
        if (i_iValue == msc_iUpdateNames)
        {
          UpdateNames (this.GetType ());
          return;
        }
        else if (i_iValue > ms_iAutoValue)
          ms_iAutoValue = i_iValue;
        else
          i_iValue = ++ms_iAutoValue;
        if (ms_listiValue.Contains (i_iValue))
          throw new ArgumentException ("duplicate value " + i_iValue.ToString ());
        Value = i_iValue;
        ms_listiValue.Add (i_iValue);
      }
      private static void UpdateNames (Type i_oType)
      {
        if (i_oType == null)
          return;
        FieldInfo[] aoFieldInfo = i_oType.GetFields (BindingFlags.Public | BindingFlags.Static);
        foreach (FieldInfo oFieldInfo in aoFieldInfo)
        {
          CEnum oEnumResult = oFieldInfo.GetValue (null) as CEnum;
          if (oEnumResult == null)
            continue;
          oEnumResult.Name = oFieldInfo.Name;
        }
      }
    }
