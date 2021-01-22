private static string CheckBoxWithValue(this HtmlHelper htmlHelper, string name, object value, bool isChecked, bool setId, IDictionary<string, object> htmlAttributes)
		{
			const InputType inputType = InputType.CheckBox;
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("null or empty error", "name");
			}
			var tagBuilder = new TagBuilder("input");
			tagBuilder.MergeAttributes(htmlAttributes);
			tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
			tagBuilder.MergeAttribute("name", name, true);
			string valueParameter = Convert.ToString(value, CultureInfo.CurrentCulture);
			if (isChecked)
			{
				tagBuilder.MergeAttribute("checked", "checked");
			}
			tagBuilder.MergeAttribute("value", valueParameter, true);
			if (setId) tagBuilder.GenerateId(name);
			// If there are any errors for a named field, we add the css attribute.
			ModelState modelState;
			if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
			{
				if (modelState.Errors.Count > 0)
				{
					tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
				}
			}
			var inputItemBuilder = new StringBuilder();
			inputItemBuilder.Append(tagBuilder.ToString(TagRenderMode.SelfClosing));
			var hiddenInput = new TagBuilder("input");
			hiddenInput.MergeAttributes(htmlAttributes); 
			hiddenInput.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Hidden));
			hiddenInput.MergeAttribute("name", name);
			if (setId)
			{
				hiddenInput.GenerateId(name);
			}
			hiddenInput.MergeAttribute("value", valueParameter);
			
			inputItemBuilder.Append(hiddenInput.ToString(TagRenderMode.SelfClosing));
			return inputItemBuilder.ToString();
		}
