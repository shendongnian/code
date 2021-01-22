	public class AuctionItemModelBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext,
			ModelBindingContext bindingContext) {
			NameValueCollection form = controllerContext.HttpContext.Request.Form;
			Registry registry = new Registry();
			var item = registry.ResolveTypeFrom<IAuctionItem>();
			item.Description = form["title"];
			item.Price = int.Parse(form["price"]);
			item.Title = form["title"];
			//TODO: Stop hardcoding this
			item.UserId = 1;
			return item;
		}
	}
