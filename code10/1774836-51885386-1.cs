	@model DynamicViewExample.Controllers.ProductViewModel
	@{
		ViewBag.Title = "About";
	}
	@using (Html.BeginForm())
	{
		<h2>Add</h2>
		@Html.DisplayFor(m => m.Products)
		<p>Begin building a question set by clicking the button below.</p>
		<input type="submit" value="Add Product" />
	}
