    public class AgeModel: IValidatableObject
	{
		[DataType(DataType.Date)]
		public DateTime Birth { get; set; }
		[DataType(DataType.Date)]
		public DateTime Death { get; set; }
		public TimeSpan Age
		{
			get
			{
				return this.Death.Subtract(this.Birth);
			}
		}
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (this.Death < this.Birth)
				yield return new ValidationResult("It died before birth", new[] { nameof(this.Death) });
			if (this.Birth > this.Death)
				yield return new ValidationResult("It born after death", new[] { nameof(this.Birth) });
		}
	}
