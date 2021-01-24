        class PlanTierComparer : IEqualityComparer<PlanTier>
        {
            public static readonly PlanTierComparer Instance = new PlanTierComparer();
            PlanTierComparer() { }
            public bool Equals(PlanTier x, PlanTier y)
            {
                if (x == null && y == null)
                    return true;
                if (x == null || y == null)
                    return false;
                return x.PlanName == y.PlanName && x.Tiers == y.Tiers;
            }
            public int GetHashCode(PlanTier obj)
            {
                return obj != null ? obj.PlanName.GetHashCode() ^ obj.Tiers.GetHashCode() : 0;
            }
        }
