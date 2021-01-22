	public class Sorter<T>: IComparer<T>
	{
		public string Propiedad { get; set; }
		public Sorter(string propiedad)
		{
			this.Propiedad = propiedad;
		}
		public int Compare(T x, T y)
		{
			PropertyInfo property = x.GetType().GetProperty(this.Propiedad);
			if (property == null)
				throw new ApplicationException("El objeto no tiene la propiedad " + this.Propiedad);
			return Comparer.DefaultInvariant.Compare(property.GetValue(x, null), property.GetValue(y, null));
		}
	}
