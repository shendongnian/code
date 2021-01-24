    private void Repeat(object state)
	{
		public IList<MyClass> GetMyClass(int id, bool show)
		{
			using (var ctx = new DbContext())
			{
				return ctx.MyClasses.Where(x =>
					   x.Id == id &&
					   (x.Show == show || !show && x.show == null)
					   .OrderByDescending(x => x.CreationDate).Take(100).ToList();
			}
		}
	}
