    delegate byte[] GetDataHandler(int offset, int length);
    interface IScanner{
        void   Scan(byte[] data);
        byte[] Parse(GetDataHandler getData);
    }
    class Composite{
        public byte[] GetData(int offset, int length){/*...*/}
    }
    
    class CompositeScanner{}
        IScanner realScanner;
    
        public void ScanComposite(Composite c){
            realScanner.Scan(realScanner.Parse(delegate(int offset, int length){
                return c.GetData(offset, length);
            });
        }
    }
