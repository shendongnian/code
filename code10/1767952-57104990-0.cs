        ReaderCollectionImpl readerCollection;
        public ReaderCollectionImpl GetReaders()
        {
            try
            {
                readerCollection = (ReaderCollectionImpl)UareUGlobal.GetReaderCollection(Android.App.Application.Context);
                readerCollection.GetReaders();                
                return readerCollection;
            }
            catch(UareUException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int GetSize()
        {
            return readerCollection.Size();
        }
        public string GetName()
        {
            return (readerCollection.Get(0) as ReaderCollectionImpl.ReaderImpl).Description.Name;
        }
