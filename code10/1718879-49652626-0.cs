	public class BaseButton : Button
	{
		public BaseButton()
		{
			Clicked += async (sender,e) =>
			{
				BackgroundColor = BaseColors.ButtonPressedBackgroundColor;
				TextColor = BaseColors.ButtonPressedTextColor;
				BorderColor = BaseColors.ButtonPressedBorderColor;
				await Task.Delay(200); // wait for 200ms
				BackgroundColor = BaseColors.ButtonBackgroundColor;
				TextColor = BaseColors.ButtonTextColor;
				BorderColor = BaseColors.ButtonBorderColor;
				await Task.Delay(200); // wait for 200ms
				
				// process the click after the 400ms total waiting
				ProcessTheClick();
			};              
		}
	}
