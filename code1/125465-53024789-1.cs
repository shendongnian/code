	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace Hidistro.UI.Common.Controls
	{
		/// <summary>
		/// Just like a normal RadioButton, except that the wrapped span is disabled.
		/// </summary>
		public class CleanRadioButton : RadioButton
		{
			protected override void Render(HtmlTextWriter writer)
			{
				List<string> keysToRemove = new List<string>();
				foreach (object key in Attributes.Keys)
				{
					string keyString = (string)key;
					InputAttributes.Add(keyString, Attributes[keyString]);
					keysToRemove.Add(keyString);
				}
				foreach (string key in keysToRemove)
					Attributes.Remove(key);
				base.Render(writer);
			}
		}
	}
	
	
	
	
	
	
