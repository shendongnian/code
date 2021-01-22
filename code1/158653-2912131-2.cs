    public static string ComboDaysOfWeek(this HtmlHelper helper, string id, string selectedValue)
    {
        var newitems = DateTimeFormatInfo
            .InvariantInfo
            .DayNames
            .Select((dayName, index) => new SelectListItem
            {
                Value = (index + 1).ToString(),
                Text = dayName,
                Selected = (selectedValue == (index + 1).ToString())
            });
        var result = helper.DropDownList(id, newitems).ToHtmlString();
        return result;
    }
