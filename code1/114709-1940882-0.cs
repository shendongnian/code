        class MyEnumerator : IEnumerator<string>
        {
            // ...
            #region IDisposable Members
            public void Dispose()
            {
                // do your cleanup here
                throw new NotImplementedException();
            }
            #endregion
            // ...
        }
