    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    namespace COMTest
    {
       [Guid("AC4C4347-27EA-4735-B9F2-CF672B4CBB4A")]
       [ComVisible(true)]
       public interface ICOMTest
       {
           [ComVisible(true)]
           DataSet GetDataSet();
       }
       [Guid("CB733AB1-9DFC-437d-A769-203DD7282A8C")]
       [ProgId("COMTest.COMTest")]
       [ComVisible(true)]
       public class COMTest : ICOMTest
       {
           public DataSet GetDataSet()
           {
               DataSet ds = new DataSet("COMTest");
               return ds;
           }
       }
