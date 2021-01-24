    public class BaseEntityPolicy : IEntityPolicy<BaseEntity>
    {
        public string GetPolicyResult(BaseEntity entity) { return nameof(BaseEntityPolicy); }
    }
    public class GrandChildAEntityPolicy : IEntityPolicy<GrandChildAEntity>
    {
        public string GetPolicyResult(BaseEntity entity) { return nameof(GrandChildAEntityPolicy); }
    }
    public class ChildBEntityPolicy: IEntityPolicy<ChildBEntity>
    {
        public string GetPolicyResult(BaseEntity entity) { return nameof(ChildBEntityPolicy); }
    }
