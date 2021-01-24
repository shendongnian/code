	@for (var i = 0; i < Model.Length; i++)
	{
		var item = Model[i];
		@if (item.Activated == null)
		{
			using (Html.BeginForm("Update", "User", new { id = item.Id }))
			{
				@Html.AntiForgeryToken()
				@Html.HiddenFor(_ => Model[i].Id)
				<td class="button btn-default" align="center">
					<input type="submit" value="Activate" class="btn btn-default" />
				</td>
			}
		}
		else if (item.Activated == "Yes")
		{
			<td class="c" align="center">
				Activated already
			</td>
		}
	
