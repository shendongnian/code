    public class DriversLicense
    {
            public virtual Person Person { get; set; }
            public virtual string State { get; set; }
            
            public override bool Equals( object obj )
            {
                if( ReferenceEquals( obj, null ) ) return false;
                // Cast, instead of 'as' throws runtime exception when obj is not an 
                // DriversLicense.
                var comp = (DriversLicense) obj;
                if( Person == null || comp.Person == null )
                    return false;
                return Person.Equals( comp.Person );
            }
            public override int GetHashCode() 
            {
				return Account == null ? -1 : Account.GetHashCode(); 
			}
    }
    public class DriversLicenseMap : ClassMap<DriversLicense>
    {
            public DriversLicenseMap()
            {
                    UseCompositeId().WithKeyReference( x => x.Person );
                    Map( x => x.State );
            }
    }
