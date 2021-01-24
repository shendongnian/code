     public static MvcHtmlString GenerateStepTwo(this HtmlHelper<InputModell> html, InputModell modell)
        {
         ...
         foreach (var actField in fieldsSorted)
            {
            ...
            editor = html.Editor(fieldname, new { htmlAttributes = new { @class = "form-control", style = "max-width:200px;min-width:100px" } });
            all.AppendLine(AddOpenImageFunc(editor, fieldname));
    ...
    }
    return all;
