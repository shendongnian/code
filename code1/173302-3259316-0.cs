    public class MyRecord : RecordBase
    {
        public XAxis
        {
            get
            {
                switch (metadata.XAxisColumn)
                {
                    // for example only; this code will not compile because it depends what kind of object RecordBase is :)
                case X:
                    return this.X;
                case Y:
                    return this.Y;        
                }
            }
        }
    }
