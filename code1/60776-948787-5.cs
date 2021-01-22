        public class ImplementingClass : IInterface
        {
            #region IInterface Members
            public string GetString(string key)
            {
                return "hello world";
            }
            //public short GetShort(string key)
            //{
            //    return 1;
            //}
            #endregion
        }
