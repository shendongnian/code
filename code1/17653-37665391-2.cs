     public class FoobarHandRolled
        {
            public FoobarHandRolled(string name, int age, bool isContent, DateTime birthDay)
            {
                Name = name;
                Age = age;
                IsContent = isContent;
                BirthDay = birthDay;
            }
    
            public FoobarHandRolled(string xml)
            {
                if (string.IsNullOrWhiteSpace(xml))
                {
                    return;
                }
    
                SetName(xml);
                SetAge(xml);
                SetIsContent(xml);
                SetBirthday(xml);
            }
    
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsContent { get; set; }
            public DateTime BirthDay { get; set; }
    
            /// <summary>
            ///     Takes this object and creates an XML representation.
            /// </summary>
            /// <returns>An XML string that represents this object.</returns>
            public override string ToString()
            {
                var builder = new StringBuilder();
                builder.Append("<FoobarHandRolled>");
    
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    builder.Append("<Name>" + Name + "</Name>");
                }
    
                builder.Append("<Age>" + Age + "</Age>");
                builder.Append("<IsContent>" + IsContent + "</IsContent>");
                builder.Append("<BirthDay>" + BirthDay.ToString("yyyy-MM-dd") + "</BirthDay>");
                builder.Append("</FoobarHandRolled>");
    
                return builder.ToString();
            }
    
            private void SetName(string xml)
            {
                Name = GetSubString(xml, "<Name>", "</Name>");
            }
    
            private void SetAge(string xml)
            {
                var ageString = GetSubString(xml, "<Age>", "</Age>");
                int result;
                var success = int.TryParse(ageString, out result);
                if (success)
                {
                    Age = result;
                }
            }
    
            private void SetIsContent(string xml)
            {
                var isContentString = GetSubString(xml, "<IsContent>", "</IsContent>");
                bool result;
                var success = bool.TryParse(isContentString, out result);
                if (success)
                {
                    IsContent = result;
                }
            }
    
            private void SetBirthday(string xml)
            {
                var dateString = GetSubString(xml, "<BirthDay>", "</BirthDay>");
                DateTime result;
                var success = DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, DateTimeStyles.None, out result);
                if (success)
                {
                    BirthDay = result;
                }
            }
    
            private string GetSubString(string xml, string startTag, string endTag)
            {
                var startIndex = xml.IndexOf(startTag, StringComparison.Ordinal);
                if (startIndex < 0)
                {
                    return null;
                }
    
                startIndex = startIndex + startTag.Length;
    
                var endIndex = xml.IndexOf(endTag, StringComparison.Ordinal);
                if (endIndex < 0)
                {
                    return null;
                }
    
                return xml.Substring(startIndex, endIndex - startIndex);
            }
        }
