	public class MyIndex : AbstractIndexCreationTask<Contact>
	{
		public MyIndex()
		{
			Map = contacts =>
				from e in contacts
				select new
				{
					_ = e.CustomFields.Select( x => CreateField ($"{nameof(Contact.CustomFields)}_{x.Key}", x.Value))
				};
		}
	} 
