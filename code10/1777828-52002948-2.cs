        class PlanTier : IEquatable<PlanTier>
        {
            public PlanTier(string planName, string tiers)
            {
                PlanName = planName ?? throw new ArgumentNullException(nameof(planName));
                Tiers = tiers ?? throw new ArgumentNullException(nameof(tiers));
            }
            public string PlanName { get; }
            public string Tiers { get; }
            public override bool Equals(object obj)
            {
                return obj is PlanTier other ? Equals(other) : false;
            }
            public override int GetHashCode()
            {
                return PlanName.GetHashCode() ^ Tiers.GetHashCode();
            }
            public bool Equals(PlanTier other)
            {
                if (other == null)
                    return false;
                return PlanName == other.PlanName && Tiers == other.Tiers;
            }
        }
