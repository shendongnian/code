	public interface BaseInterface<L, T> where L : IList<T>
	{
		L ListProperty { get; set; }
	}
	
	public class NewClass : BaseInterface<List<double>, double>
	{
		public List<double> ListProperty { get; set; }
	}
