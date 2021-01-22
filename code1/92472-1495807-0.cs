        private List<Bucket> ProcessXML(XDocument targetdata)
        {
		return new List<Bucket>(
                     from e in targetdata.Elements()
                     from d in e.Elements()
                     select new Bucket
                     {
                         count = (int)d.Attribute("count"),
                         truncated = (int)d.Attribute("trunc"),
                         bucket = (string)d.Element("value").Value
                     });
        }
        /*
        <BucketizerTarget truncated="0" buckets="256">
          <Slot count="2715303" trunc="0">
            <value>14</value>
          </Slot>
        </BucketizerTarget>
        */
    public class Bucket
    {
        internal string bucket;
        internal int count;
        internal int truncated;
        public string BucketSlot
        {
            get { return bucket; }
        }
        public int Count
        {
            get { return count; }
        }
        public int Truncated
        {
            get { return truncated; }
        }
    }
