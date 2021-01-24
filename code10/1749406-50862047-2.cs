    public class Members
    {
        public int IdKey;
        public string name;
        public string relationBegin;
        public string relationEnd;
        public bool isOriginal;
        public DateTime RelationBeginDate
        {
            get { return DateTime.ParseExact(relationBegin, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture); }
        }
        public DateTime RelationEndDate
        {
            get { return DateTime.ParseExact(relationEnd, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture); }
        }
        public Members(int IdKey, string name, string relationBegin, string relationEnd, bool isOriginal)
        {
            //assign paramters to proper properties
        }
    }
