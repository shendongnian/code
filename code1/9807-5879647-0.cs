	private static Regex s_NamedFormatRegex = new Regex(@"\{(?!\{)(?<key>[\w]+)(:(?<fmt>(\{\{|\}\}|[^\{\}])*)?)?\}", RegexOptions.Compiled);
	public static StringBuilder AppendNamedFormat(this StringBuilder builder,IFormatProvider provider, string format, IDictionary<string, object> args)
	{
		if (builder == null) throw new ArgumentNullException("builder");
		var str = s_NamedFormatRegex.Replace(format, (mt) => {
			string key = mt.Groups["key"].Value;
			string fmt = mt.Groups["fmt"].Value;
			object value = null;
			if (args.TryGetValue(key,out value)) {
				return string.Format(provider, "{0:" + fmt + "}", value);
			} else {
				return mt.Value;
			}
		});
		builder.Append(str);
		return builder;
	}
	public static StringBuilder AppendNamedFormat(this StringBuilder builder, string format, IDictionary<string, object> args)
	{
		if (builder == null) throw new ArgumentNullException("builder");
		return builder.AppendNamedFormat(null, format, args);
	}
