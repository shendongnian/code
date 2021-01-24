    @model Models.ConfigureStatesModel
    @for (int outer = 0; outer < Model.States.Count; outer++)
    {
        <div class="states">
			@Html.TextBoxFor(m => m.States[outer].Name, new { @class="state" })
			for (int inner = 0; inner < Model.States[outer].Cities.Count; inner++)
			{
				<div class="cities">
					@Html.TextBoxFor(m => m.States[outer].Cities[inner].Name)
					@Html.TextBoxFor(m => m.States[outer].Cities[inner].Population)
				</div>
			}
		</div>
    }
