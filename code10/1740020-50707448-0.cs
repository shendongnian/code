    public class DateFormatter : CodeActivity
	{
		public const string DEFAULT_LOCALE = "en-us";
		[Input("Date")]
		[RequiredArgument]
		public InArgument<DateTime> Date
		{
			get;
			set;
		}
		[Input("Locale")]
		[Default(DEFAULT_LOCALE)]
		public InArgument<string> Locale
		{
			get;
			set;
		}
		[Input("Format")]
		public InArgument<string> Format
		{
			get;
			set;
		}
		[Output("Formatted Date")]
		public OutArgument<string> DateAsString
		{
			get;
			set;
		}
		protected override void Execute(CodeActivityContext context)
		{
			DateTime? date = this.Date.Get(context);
			string locale = this.Locale.Get(context);
			string format = this.Format.Get(context);
			if (date.HasValue == false)
			{
				this.DateAsString.Set(context, null);
				return;
			}
			DateTime value = date.Value;
			CultureInfo culture = CultureInfo.GetCultureInfo(locale ?? DEFAULT_LOCALE);
			string dateAsString = (format == null) ? value.ToString(culture) : value.ToString(format, culture);
			this.DateAsString.Set(context, dateAsString);
		}
	}
