	[JsonConverter(typeof(GuardianPatientConverter))]
	class GuardianPatient
	{
		public Guardian Guardian { get; set; }
		public Patient Patient { get; set; }
	}
