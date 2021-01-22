    public class DataBaseRecordInfo
    {
        public long NumID1 { get; set; }
        public int NumID2 { get; set; }
        public short NumID3 { get; set; }
        public static Type GetType(DatabaseField field)
        {
            string name = field.ToString();
            Type recordType = typeof (DataBaseRecordInfo);
            var props = recordType.GetProperties();
            var matchedProperty = props.Where(p => name == p.Name).FirstOrDefault();
            if (matchedProperty == null)
                return null;    // We do not have a matching property.
            return matchedProperty.PropertyType;
        }
    };
