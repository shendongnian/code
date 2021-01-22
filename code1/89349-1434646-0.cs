	public class CompanyDescription : IDescription { public string Text { get; set; } }
	public class LocationDescription : IDescription { public string Text { get; set; } }
	public class Company : IHaveDescriptions<CompanyDescription>
	{
	   public IList<CompanyDescription> Desriptions { get; set; }
	}
	public class Location : IHaveDescriptions<LocationDescription>
	{
	   public IList<LocationDescription> Desriptions { get; set; }
	}
	public interface IDescription
	{
		string Text { get; set; }
	}
	public interface IHaveDescriptions<T>
		where T : class, IDescription, new()
	{
		IList<T> Desriptions { get; set; }
	}
	public static class DescriptionInterfaceExtensions
	{
		public static void AddDescription<T>(this IHaveDescriptions<T> entity, string text)
			where T : class, IDescription, new()
		{
			T newDescription = new T();
			newDescription.Text = text;
			entity.Desriptions.Add(newDescription);
		}
		public static void EditDescription<T>(this IHaveDescriptions<T> entity, T original, string text)
			where T : class, IDescription, new()
		{
			T newDescription = new T();
			newDescription.Text = text;
			entity.Desriptions.Remove(original);
			entity.Desriptions.Add(newDescription);
		}
	} 
