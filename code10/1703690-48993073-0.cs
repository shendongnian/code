    public class TPRelatedCaseComparer : IEqualityComparer<TPRelatedCase>
    {
        public bool Equals(TPRelatedCase x, TPRelatedCase y)
        {
            var xJson = JsonConvert.SerializeObject(x);
            var yJson = JsonConvert.SerializeObject(y);
            return xJson.Equals(yJson);
        }
        public int GetHashCode(TPRelatedCase obj)
        {
            return obj.BusinessSystemId.GetHashCode() + obj.CaseId.GetHashCode() + obj.RelationshipNo.GetHashCode();
        }
    }
