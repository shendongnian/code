    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute(string name)
        {
            this.DisplayName = name;
        }
        public string DisplayName { get; private set; }
    }
    public static class EnumUtils
    {
        private static Dictionary<Type, IDictionary<object, string>> _nameLookups = 
            new Dictionary<Type, IDictionary<object, string>>();
        public static string GetDisplayName<T>(this T value)
        {
            var type = typeof(T);
            if (!_nameLookups.ContainsKey(type))
            {
                _nameLookups[typeof(T)] = GetEnumFields<T>()
                    .ToDictionary(
                        f => f.GetValue(null),
                        f => f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)
                                .OfType<EnumDisplayNameAttribute>()
                                .Select(a => a.DisplayName)
                                .FirstOrDefault() 
                            ?? f.Name);
            }
            return _nameLookups[type][value];
        }
        public static IEnumerable<FieldInfo> GetEnumFields<T>()
        {
            return typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .OfType<FieldInfo>();
        }
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString EnumDropdownFor<TModel, TValue>(
            this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TValue>> expression)
        {
            var data = expression.Compile()(helper.ViewData.Model);
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(
                "<select name='{0}' id='{0}'>", 
                helper.Encode(
                    (expression.Body as MemberExpression).Member.Name));
            EnumUtils.GetEnumFields<TValue>()
                .ForEach(f => {
                    var nameAttrib = f
                        .GetCustomAttributes(
                            typeof(EnumDisplayNameAttribute), true)
                        .OfType<EnumDisplayNameAttribute>().FirstOrDefault();
                    var displayName = (nameAttrib == null)
                        ? f.Name : nameAttrib.DisplayName;
                    var optionData = (TValue)f.GetRawConstantValue();
                    builder.AppendFormat(
                        "<option value=\"{0}\" {1}>{2}</option>",
                        optionData, 
                        optionData.Equals(data) ? "selected=\"selected\"" : "",
                        displayName);
                }
            );
            builder.Append("</select>");
            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString EnumDropdown<TModel, TValue>(
            this HtmlHelper<TModel> helper, string name, TValue value)
        {
            return helper.EnumDropdown(
                name, value, EnumUtils.GetEnumValues<TValue>());
        }
        public static MvcHtmlString EnumDropdown<TModel, TValue>(
            this HtmlHelper<TModel> helper, string name, 
            IEnumerable<TValue> choices)
        {
            return helper.EnumDropdown(name, choices.FirstOrDefault(), choices);
        }
        public static MvcHtmlString EnumDropdown<TModel, TValue>(
            this HtmlHelper<TModel> helper, string name, TValue value,
            IEnumerable<TValue> choices)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<select name='{0}'>", helper.Encode(name));
            if (choices != null)
            {
                choices.ForEach(
                    c => builder.AppendFormat(
                        "<option value=\"{0}\"{2}>{1}</option>",
                        Convert.ToInt32(c),
                        helper.Encode(EnumUtils.GetDisplayName(c)),
                        value.Equals(c) ? " selected='selected'" : ""));
            }
            builder.Append("</select>");
            return MvcHtmlString.Create(builder.ToString());
        }
    }
