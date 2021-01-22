    namespace XYZ.DEF
    {
        public class GHI {}
    }
    namespace QRS.DEF.GHI
    {
        public class JKL { }
    }
    ...
    using QRS;
    namespace TUV 
    {
      using XYZ;
      namespace ABC
      {
        namespace DEF 
        {
            class GHI { }
            class MNO : DEF.GHI.JKL { }
        }
      }
    }
    
