    using Microsoft.VisualStudio.TestTools.UnitTesting;
	namespace EmailValidateUnitTests
	{
		[TestClass]
		public class EmailValidationUnitTests
		{
			[TestMethod]
			public void TestEmailValidate()
			{
				// Positive Assertions
				Assert.IsTrue("prettyandsimple@example.com".IsValidEmailAddress());
				Assert.IsTrue("very.common@example.com".IsValidEmailAddress());
				Assert.IsTrue("disposable.style.email.with+symbol@example.com".IsValidEmailAddress());
				Assert.IsTrue("other.email-with-dash@example.com".IsValidEmailAddress());
				Assert.IsTrue("\"much.more unusual\"@example.com".IsValidEmailAddress());
				Assert.IsTrue("\"very.unusual.@.unusual.com\"@example.com".IsValidEmailAddress()); //"very.unusual.@.unusual.com"@example.com
				Assert.IsTrue("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com".IsValidEmailAddress()); //"very.(),:;<>[]\".VERY.\"very@\\ \"very\".unusual"@strange.example.com
				Assert.IsTrue("admin@mailserver1".IsValidEmailAddress());
				Assert.IsTrue("#!$%&'*+-/=?^_`{}|~@example.org".IsValidEmailAddress());
				Assert.IsTrue("\"()<>[]:,;@\\\\\\\"!#$%&'*+-/=?^_`{}| ~.a\"@example.org".IsValidEmailAddress()); //"()<>[]:,;@\\\"!#$%&'*+-/=?^_`{}| ~.a"@example.org
				Assert.IsTrue("\" \"@example.org".IsValidEmailAddress()); //" "@example.org (space between the quotes)
				Assert.IsTrue("example@localhost".IsValidEmailAddress());
				Assert.IsTrue("example@s.solutions".IsValidEmailAddress());
				Assert.IsTrue("user@com".IsValidEmailAddress());
				Assert.IsTrue("user@localserver".IsValidEmailAddress());
				Assert.IsTrue("user@[IPv6:2001:db8::1]".IsValidEmailAddress());
				Assert.IsTrue("user@[192.168.2.1]".IsValidEmailAddress());
				Assert.IsTrue("(comment and stuff)joe@gmail.com".IsValidEmailAddress());
				Assert.IsTrue("joe(comment and stuff)@gmail.com".IsValidEmailAddress());
				Assert.IsTrue("joe@(comment and stuff)gmail.com".IsValidEmailAddress());
				Assert.IsTrue("joe@gmail.com(comment and stuff)".IsValidEmailAddress());
				// Failure Assertions
				Assert.IsFalse("joe(fail me)smith@gmail.com".IsValidEmailAddress());
				Assert.IsFalse("joesmith@gma(fail me)il.com".IsValidEmailAddress());
				Assert.IsFalse("joe@gmail.com(comment and stuff".IsValidEmailAddress());
				Assert.IsFalse("Abc.example.com".IsValidEmailAddress());
				Assert.IsFalse("A@b@c@example.com".IsValidEmailAddress());
				Assert.IsFalse("a\"b(c)d,e:f;g<h>i[j\\k]l@example.com".IsValidEmailAddress()); //a"b(c)d,e:f;g<h>i[j\k]l@example.com
				Assert.IsFalse("just\"not\"right@example.com".IsValidEmailAddress()); //just"not"right@example.com
				Assert.IsFalse("this is\"not\\allowed@example.com".IsValidEmailAddress()); //this is"not\allowed@example.com
				Assert.IsFalse("this\\ still\\\"not\\\\allowed@example.com".IsValidEmailAddress());//this\ still\"not\\allowed@example.com
				Assert.IsFalse("john..doe@example.com".IsValidEmailAddress());
				Assert.IsFalse("john.doe@example..com".IsValidEmailAddress());
				Assert.IsFalse(" joe@gmail.com".IsValidEmailAddress());
				Assert.IsFalse("joe@gmail.com ".IsValidEmailAddress());
			}
		}
		public static class ExtensionMethods
		{
			private const string ValidLocalPartChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&'*+-/=?^_`{|}~";
			private const string ValidQuotedLocalPartChars = "(),:;<>@[]. ";
			private const string ValidDomainPartChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-:";
			private enum EmailParseMode
			{
				BeginLocal, Local, QuotedLocalEscape, QuotedLocal, QuotedLocalEnd, LocalSplit, LocalComment,
				At,
				Domain, DomainSplit, DomainComment, BracketedDomain, BracketedDomainEnd
			};
			public static bool IsValidEmailAddress(this string s)
			{
				bool valid = true;
				bool hasLocal = false, hasDomain = false;
				int commentStart = -1, commentEnd = -1;
				var mode = EmailParseMode.BeginLocal;
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if (mode == EmailParseMode.BeginLocal || mode == EmailParseMode.LocalSplit)
					{
						if (c == '(') { mode = EmailParseMode.LocalComment; commentStart = i; commentEnd = -1; }
						else if (c == '"') { mode = EmailParseMode.QuotedLocal; }
						else if (ValidLocalPartChars.IndexOf(c) >= 0) { mode = EmailParseMode.Local; hasLocal = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.LocalComment)
					{
						if (c == ')')
						{
							mode = EmailParseMode.Local; commentEnd = i;
							// comments can only be at beginning and end of parts...
							if (commentStart != 0 && ((commentEnd + 1) < s.Length) && s[commentEnd + 1] != '@') { valid = false; break; }
						}
					}
					else if (mode == EmailParseMode.Local)
					{
						if (c == '.') mode = EmailParseMode.LocalSplit;
						else if (c == '@') mode = EmailParseMode.At;
						else if (c == '(') { mode = EmailParseMode.LocalComment; commentStart = i; commentEnd = -1; }
						else if (ValidLocalPartChars.IndexOf(c) >= 0) { hasLocal = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.QuotedLocal)
					{
						if (c == '"') { mode = EmailParseMode.QuotedLocalEnd; }
						else if (c == '\\') { mode = EmailParseMode.QuotedLocalEscape; }
						else if (ValidLocalPartChars.IndexOf(c) >= 0 || ValidQuotedLocalPartChars.IndexOf(c) >= 0) { hasLocal = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.QuotedLocalEscape)
					{
						if (c == '"' || c == '\\') { mode = EmailParseMode.QuotedLocal; hasLocal = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.QuotedLocalEnd)
					{
						if (c == '.') { mode = EmailParseMode.LocalSplit; }
						else if (c == '@') mode = EmailParseMode.At;
						else if (c == '(') { mode = EmailParseMode.LocalComment; commentStart = i; commentEnd = -1; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.At)
					{
						if (c == '[') { mode = EmailParseMode.BracketedDomain; }
						else if (c == '(') { mode = EmailParseMode.DomainComment; commentStart = i; commentEnd = -1; }
						else if (ValidDomainPartChars.IndexOf(c) >= 0) { mode = EmailParseMode.Domain; hasDomain = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.DomainComment)
					{
						if (c == ')')
						{
							mode = EmailParseMode.Domain;
							commentEnd = i;
							// comments can only be at beginning and end of parts...
							if ((commentEnd + 1) != s.Length && (commentStart > 0) && s[commentStart - 1] != '@') { valid = false; break; }
						}
					}
					else if (mode == EmailParseMode.DomainSplit)
					{
						if (ValidDomainPartChars.IndexOf(c) >= 0) { mode = EmailParseMode.Domain; hasDomain = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.Domain)
					{
						if (c == '(') { mode = EmailParseMode.DomainComment; commentStart = i; commentEnd = -1; }
						else if (c == '.') { mode = EmailParseMode.DomainSplit; }
						else if (ValidDomainPartChars.IndexOf(c) >= 0) { hasDomain = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.BracketedDomain)
					{
						if (c == ']') { mode = EmailParseMode.BracketedDomainEnd; }
						else if (c == '.' || ValidDomainPartChars.IndexOf(c) >= 0) { hasDomain = true; }
						else { valid = false; break; }
					}
					else if (mode == EmailParseMode.BracketedDomain)
					{
						if (c == '(') { mode = EmailParseMode.DomainComment; commentStart = i; commentEnd = -1; }
						else { valid = false; break; }
					}
				}
				bool unfinishedComment = (commentEnd == -1 && commentStart >= 0);
				return hasLocal && hasDomain && valid && !unfinishedComment;
			}
		}
	}
