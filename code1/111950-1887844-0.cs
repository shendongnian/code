    public class ClaimMap : ClassMap<Claim>
    {
      public ClaimMap()
      {
        Id(x => x.Id);
        DiscriminateSubClassesOnColumn("InvolvedPartyContext");
      }
    }
    public class VehicleClaimMap : SubclassMap<VehicleClaim>
    {
      public VehicleClaimMap()
      {
        DiscriminatorValue(1);
        References(x => x.Vehicle);
      }
    }
