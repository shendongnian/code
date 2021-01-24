	public static void SetLanguage(string locale)
	{
		if (string.IsNullOrEmpty(locale)) locale = "en-US";
		TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(locale);
	}
