	/// <summary>
	/// Read in a line of text, and use the Add() function to add these items to the current CSV structure
	/// </summary>
	/// <param name="s"></param>
	public static bool TryParseCSVLine(string s, char delimiter, char text_qualifier, out string[] array)
	{
		bool success = true;
		List<string> list = new List<string>();
		StringBuilder work = new StringBuilder();
		for (int i = 0; i < s.Length; i++) {
			char c = s[i];
			// If we are starting a new field, is this field text qualified?
			if ((c == text_qualifier) && (work.Length == 0)) {
				int p2;
				while (true) {
					p2 = s.IndexOf(text_qualifier, i + 1);
					// for some reason, this text qualifier is broken
					if (p2 < 0) {
						work.Append(s.Substring(i + 1));
						i = s.Length;
						success = false;
						break;
					}
					// Append this qualified string
					work.Append(s.Substring(i + 1, p2 - i - 1));
					i = p2;
					// If this is a double quote, keep going!
					if (((p2 + 1) < s.Length) && (s[p2 + 1] == text_qualifier)) {
						work.Append(text_qualifier);
						i++;
						// otherwise, this is a single qualifier, we're done
					} else {
						break;
					}
				}
				// Does this start a new field?
			} else if (c == delimiter) {
				list.Add(work.ToString());
				work.Length = 0;
				// Test for special case: when the user has written a casual comma, space, and text qualifier, skip the space
				// Checks if the second parameter of the if statement will pass through successfully
				// e.g. "bob", "mary", "bill"
				if (i + 2 <= s.Length - 1) {
					if (s[i + 1].Equals(' ') && s[i + 2].Equals(text_qualifier)) {
						i++;
					}
				}
			} else {
				work.Append(c);
			}
		}
		list.Add(work.ToString());
		// If we have nothing in the list, and it's possible that this might be a tab delimited list, try that before giving up
		if (list.Count == 1 && delimiter != DEFAULT_TAB_DELIMITER) {
			string[] tab_delimited_array = ParseLine(s, DEFAULT_TAB_DELIMITER, DEFAULT_QUALIFIER);
			if (tab_delimited_array.Length > list.Count) {
				array = tab_delimited_array;
				return success;
			}
		}
		// Return the array we parsed
		array = list.ToArray();
		return success;
	}
