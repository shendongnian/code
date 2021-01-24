	var segments = new List<Segment>
	{
		new Segment
		{
			Legs = new List<Leg>
			{
				new Leg {
					FlightDesignator = new FlightDesignator{
						CarrierCode = "G3",
						FlightNumber = "1040"
					}
				}
			},
			PaxSegments = new List<PaxSegment> {
				new PaxSegment { LiftStatus = "Boarded" },
				new PaxSegment { LiftStatus = "CheckedIn" }
			}
		},
		new Segment {
			Legs = new List<Leg>
			{
				new Leg{
					FlightDesignator=new FlightDesignator
					{
						CarrierCode="G3",
						FlightNumber="1016"
					}
				}
			},
			PaxSegments = new List<PaxSegment> {
				new PaxSegment { LiftStatus = "Boarded" },
				new PaxSegment { LiftStatus = "CheckedIn" }
			}
		}
	};
