   [Serializable]
   public class MyDataObject : IDataObject
   {
      public int mData;
      public MyDataObject(int data)
      {
         mData = data;
      }
      #region IDataObject Members
      public object GetData(Type format)
      {
         return mData;
      }
      <snip>
      #endregion
   }
