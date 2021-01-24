    @{
		//declare this on top of your cshtml page
		var className = "refinementContainer";
		if (countRefinements > 1 && !string.IsNullOrWhiteSpace(refinementType.ToString()))
		{
			if (refinementType.ToString().ToLower() != "micro")
			{
				className += " refinementmacro";
			}
			else if (countRefinements >= 1 && countRefinements <= 17)
			{
				className += " classIfConditionIsTrue refinementmicro";
			}
			else
			{
				className += " classIfConditionIsFalse refinementmicro";
			}
		}
	}
	<div class="@(className)">
	   //some functions
	</div>
