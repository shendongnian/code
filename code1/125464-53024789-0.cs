	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace YourNamespace
	{
		/// <summary>
		/// Just like a normal RadioButton, except that the wrapped span is disabled.
		/// </summary>
		public class CleanRadioButton : RadioButton
		{
			protected override void Render(HtmlTextWriter writer)
			{
				foreach (var key in Attributes.Keys)
				{
					if ((string)key == "class")
					{
						InputAttributes.Add("class", Attributes["class"]);
						Attributes.Remove("class");
						break;
					}
				}
				base.Render(writer);
			}
		}
	}
