	public interface BaseInterface
	{
		IList<double> ListProperty { get; set; }
	}
	
	public class NewClass : BaseInterface
	{
		public List<double> ListProperty { get; set; }
	
		IList<double> BaseInterface.ListProperty
		{
			get => this.ListProperty;
			set => this.ListProperty = value.ToList();
		}
	}
