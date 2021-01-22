    public class GuidMapper
    {
        private Dictionary<GuidTypes, Guid> mGuidMap = new Dictionary<GuidTypes, Guid>();
        public enum GuidTypes: int
        {
            Cleanup,
            Maintenance,
            Upgrade,
            Sales,
            Replacement,
            Modem,
            Audit,
            Queries
        }
        public GuidMapper()
        {
            mGuidMap.Add(GuidTypes.Cleanup, new Guid("2ED31640-BB48-499B-86C4-A2B1114BF100"));
            mGuidMap.Add(GuidTypes.Maintenance, new Guid("39D31D40-28EC-4832-827B-A11129EB2000"));
            mGuidMap.Add(GuidTypes.Upgrade, new Guid("892F8650-E38D-46D7-809A-49510111C100"));
            mGuidMap.Add(GuidTypes.Sales, new Guid("A5690E70-1111-4AFB-B44D-1DF3AD66D435"));
            mGuidMap.Add(GuidTypes.Replacement, new Guid("11E5CBA2-EDDE-4ECA-BDFD-63BDBA725C8C"));
            mGuidMap.Add(GuidTypes.Modem, new Guid("6F686C73-504B-1110-9A0B-850C26FDB25F"));
            mGuidMap.Add(GuidTypes.Audit, new Guid("30558C70-66D9-4189-9BD9-2B87D1119000"));
            mGuidMap.Add(GuidTypes.Queries, new Guid("99852420-516A-4151-B7DD-851112F56200"));
        }
        public Guid GetGuid(GuidTypes guidType)
        {
            if (mGuidMap.ContainsKey(guidType))
            {
                return mGuidMap[guidType];
            }
            return Guid.Empty;
        }
    }
