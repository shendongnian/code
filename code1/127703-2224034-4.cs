	///<summary>Appends a list of strings to a StringBuilder, separated by a separator string.</summary>
	///<param name="builder">The StringBuilder to append to.</param>
	///<param name="strings">The strings to append.</param>
	///<param name="separator">A string to append between the strings.</param>
	public static StringBuilder AppendJoin(this StringBuilder builder, IEnumerable<string> strings, string separator) {
		if (builder == null) throw new ArgumentNullException("builder");
		if (strings == null) throw new ArgumentNullException("strings");
		if (separator == null) throw new ArgumentNullException("separator");
		bool first = true;
		foreach (var str in strings) {
			if (first)
				first = false;
			else
				builder.Append(separator);
			builder.Append(str);
		}
		return builder;
	}
	///<summary>Combines a collection of strings into a single string.</summary>
	public static string Join<T>(this IEnumerable<T> strings, string separator, Func<T, string> selector) { return strings.Select(selector).Join(separator); }
	///<summary>Combines a collection of strings into a single string.</summary>
	public static string Join(this IEnumerable<string> strings, string separator) { return new StringBuilder().AppendJoin(strings, separator).ToString(); }
