	public delegate Y Function<X,Y>(X x);
	
	public class Map<X,Y>
	{
		private Function<X,Y> F;
	
		public Map(Function<X,Y> f)
		{
			F = f;
		}
	
		public ICollection<Y> Over(ICollection<X> xs){
			List<Y> ys = new List<Y>();
			foreach (X x in xs)
			{
				X x2 = x;//ys.Add(F(x));
			}
			return ys;
		}
	}
