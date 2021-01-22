	public abstract class ExceptionsBaseController<T> : Controller where T:class 
	{
		protected abstract Table<T> ExceptionsTable { get; }
		public virtual ActionResult List()
		{
			var items = ExceptionsTable;
			return View(items);
		}
	}
