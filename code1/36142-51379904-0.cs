		/// <summary>
		/// Takes a UTF-16 encoded string and encodes it as modified UTF-7.
		/// </summary>
		/// <param name="s">The string to encode.</param>
		/// <returns>A UTF-7 encoded string</returns>
		/// <remarks>IMAP uses a modified version of UTF-7 for encoding international mailbox names. For
		/// details, refer to RFC 3501 section 5.1.3 (Mailbox International Naming Convention).</remarks>
		internal static string UTF7Encode(string s) {
			StringReader reader = new StringReader(s);
			StringBuilder builder = new StringBuilder();
			while (reader.Peek() != -1) {
				char c = (char)reader.Read();
				int codepoint = Convert.ToInt32(c);
				// It's a printable ASCII character.
				if (codepoint > 0x1F && codepoint < 0x80) {
					builder.Append(c == '&' ? "&-" : c.ToString());
				} else {
					// The character sequence needs to be encoded.
					StringBuilder sequence = new StringBuilder(c.ToString());
					while (reader.Peek() != -1) {
						codepoint = Convert.ToInt32((char)reader.Peek());
						if (codepoint > 0x1F && codepoint < 0x80)
							break;
						sequence.Append((char)reader.Read());
					}
					byte[] buffer = Encoding.BigEndianUnicode.GetBytes(
						sequence.ToString());
					string encoded = Convert.ToBase64String(buffer).Replace('/', ',').
						TrimEnd('=');
					builder.Append("&" + encoded + "-");
				}
			}
			return builder.ToString();
		}
		/// <summary>
		/// Takes a modified UTF-7 encoded string and decodes it.
		/// </summary>
		/// <param name="s">The UTF-7 encoded string to decode.</param>
		/// <returns>A UTF-16 encoded "standard" C# string</returns>
		/// <exception cref="FormatException">The input string is not a properly UTF-7 encoded
		/// string.</exception>
		/// <remarks>IMAP uses a modified version of UTF-7 for encoding international mailbox names. For
		/// details, refer to RFC 3501 section 5.1.3 (Mailbox International Naming Convention).</remarks>
		internal static string UTF7Decode(string s) {
			StringReader reader = new StringReader(s);
			StringBuilder builder = new StringBuilder();
			while (reader.Peek() != -1) {
				char c = (char)reader.Read();
				if (c == '&' && reader.Peek() != '-') {
					// The character sequence needs to be decoded.
					StringBuilder sequence = new StringBuilder();
					while (reader.Peek() != -1) {
						if ((c = (char)reader.Read()) == '-')
							break;
						sequence.Append(c);
					}
					string encoded = sequence.ToString().Replace(',', '/');
					int pad = encoded.Length % 4;
					if (pad > 0)
						encoded = encoded.PadRight(encoded.Length + (4 - pad), '=');
					try {
						byte[] buffer = Convert.FromBase64String(encoded);
						builder.Append(Encoding.BigEndianUnicode.GetString(buffer));
					} catch (Exception e) {
						throw new FormatException(
							"The input string is not in the correct Format.", e);
					}
				} else {
					if (c == '&' && reader.Peek() == '-')
						reader.Read();
					builder.Append(c);
				}
			}
			return builder.ToString();
		}
