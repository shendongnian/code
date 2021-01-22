		public static String InputBox(String caption, String prompt, String defaultText)
		{
			String localInputText = defaultText;
			if (InputQuery(caption, prompt, ref localInputText))
			{
				return localInputText;
			}
			else
			{
				return "";
			}
		}
