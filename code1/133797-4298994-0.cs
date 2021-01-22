		private static String RemoveDiacritics(string text)
		{
			String normalized = text.Normalize(NormalizationForm.FormD);
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < normalized.Length; i++)
			{
				Char c = normalized[i];
				if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
					sb.Append(c);
			}
			return sb.ToString();
		}
