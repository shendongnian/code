    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    
    namespace EntityToDataSet
    {
       public class RowAdder
       {
          #region Data
          private readonly object mLockObject = new object();
          private static RowAdder mInstance;
          public static RowAdder Instance
          {
             get
             {
                if (mInstance == null)
                {
                   mInstance = new RowAdder();
                }
                return mInstance;
             }
          }
    
          object mSync;
          #endregion
    
          #region Constructor
          private RowAdder()
          {
          }
          #endregion
    
          public void Add(DataTable table, DataRow row)
          {
             lock (mLockObject)
             {
                table.Rows.Add(row);
             }
          }
       }
    }
