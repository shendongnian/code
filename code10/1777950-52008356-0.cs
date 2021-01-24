    public class Summary : ViewModelBase
	{
		private string _Title;
		public string Title
		{
			get { return _Title; }
			set { Set(ref _Title, value); }
		}
		private decimal _MathSalary;
		public decimal MathSalary
		{
			get { return _MathSalary; }
			set { Set(ref _MathSalary, value); }
		}
		private decimal _CompSciSalary;
		public decimal CompSciSalary
		{
			get { return _CompSciSalary; }
			set { Set(ref _CompSciSalary, value); }
		}
		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { Set(ref _Total, value); }
		}
	}
