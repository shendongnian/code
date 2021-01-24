	public class Law {
		public int Id { get; set; }
		public OwnerType OwnerType { get; set; }
		
		[ForeignKey(nameof(Country)]
		public int? CountryId { get; set; }
		public Country Country { get; set; }
		
		[ForeignKey(nameof(State)]
		public int? StateId { get; set; }
		public State State { get; set; }
		
		[ForeignKey(nameof(County)]
		public int? CountyId { get; set; }
		public County County { get; set; }
		
		[ForeignKey(nameof(City)]
		public int? CityId { get; set; }
		public City City { get; set; }
		
		private void Validate() {
			switch (OwnerType)
			{
				case OwnerType.Coutnry:
					if(CountryId == null)
						throw new LawValidationException("Country is requried");
				break;
				case OwnerType.State:
					if(StateId == null)
						throw new LawValidationException("State is requried");
				break;
				case OwnerType.County:
					if(CountyId == null)
						throw new LawValidationException("County is requried");
				break;
				case OwnerType.City:
					if(CityId == null)
						throw new LawValidationException("City is requried");
				break;
				default:
						throw new LawValidationException("Invalid law owner type");
			}
		}
	}
