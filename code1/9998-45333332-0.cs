       /// <summary>
       /// Decode email field value ("From", "To" or "Subject")
       /// </summary>
       /// <param name="mailSource">Email message source (string)</param>
       /// <param name="fieldName">Case insensitive email field name ("From", "To" or "Subject")</param>
       /// <param name="addressField">"true" for address fields ("From" or "To"), "false" for other fields ("Subject"). Default is true.</param>
       /// <returns>Decoded email field value (string)</returns>
       private string decodeMailPropertyValue(string mailSource, string fieldName, bool addressField = true)
       {
           fieldName = fieldName.ToLower();
		   
           Match temp =
               Regex
               .Match
               (
                    mailSource,
                    
                    @"(?:(?:\A|\r?\n)Field name: ([^\r\n]+)\r?\n){1}(?:(\s[^\r\n]*)\r?\n)*"
                    .Replace("Field name", fieldName),
                    RegexOptions.IgnoreCase
               );
           string tempStr = string.Empty;
           string fieldValue = string
                                    .Join
                                    (null,
                                        new string[1]
                                        {
                                            temp.Groups[1].Value
                                        }
                                        .Concat
                                        (
                                            temp
                                            .Groups[2]
                                            .Captures
                                            .OfType<Capture>()
                                            .Select
                                            (x =>
                                                x.Value
                                            )
                                        )
                                        .ToArray()
                                    );
           if (!string.IsNullOrEmpty(fieldValue.Trim()))
           {
               tempStr = fieldValue;
               MatchCollection temp2 =
                   Regex
                   .Matches
                   (
                        tempStr,
                        @"(?:(=\?[\w\s-_]+\?Q\?[^\?]+\?=\s*)+(<([\w-\.]+@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[\w-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?))>)*)+",
                        RegexOptions.IgnoreCase
                   );
               if (temp2.Count > 0)
               {
                   temp2
                       .OfType<Match>()
                       .Select
                       (x =>
                           {
                               var captures =
                                   x.Groups[1]
                                   .Captures
                                   .OfType<Capture>();
                               captures
                                   .Select
                                   (
                                        (y, index) =>
                                        {
                                            temp =
                                                Regex
                                                .Match
                                                (
                                                    y.Value,
                                                    @"=\?([\w\s-_]+)\?Q\?(?:""([^\?]+)""|([^\?]+))\?=\s*",
                                                    RegexOptions.IgnoreCase
                                                );
                                            
                                            string decodedStr =
                                                            Attachment
                                                            .CreateAttachmentFromString
                                                            (
                                                                string.Empty,
                                                                string
                                                                .Format
                                                                (
                                                                    "=?{0}?Q?{1}?=",
                                                                    temp.Groups[1].Value,
                                                                    Regex
                                                                    .Unescape
                                                                    (
                                                                        (temp.Groups[2].Success ? temp.Groups[2] : temp.Groups[3])
                                                                        .Value
                                                                        //Character "_" in Quoted-Printable replace spaces,
                                                                        //it will be remain intact after decoding (only for .NET version < 4.0), so replace this one with space before decoding.
                                                                        .Replace('_', ' ')
                                                                    )
                                                                )
                                                            )
                                                            .Name;
                                            return
                                                tempStr =
                                                    tempStr
                                                    .Replace
                                                    (
                                                        y.Value,
                                                        
                                                        decodedStr
                                                        .PadRight(x.Groups[2].Success && index == captures.Count() - 1 ? decodedStr.Length + 1 : 0)
                                                    );
                                        }
                               )
                               .ToList();
                               if (x.Groups[2].Success)
                                   tempStr =
                                       tempStr
                                       .Replace(x.Groups[2].Value, x.Groups[3].Value);
                               return
                                   tempStr;
                           }
                       )
                       .ToList();
                   fieldValue = tempStr;
               }
               else
               {
                   temp2 =
                       Regex
                       .Matches
                       (
                            tempStr,
                            @"(?:(=\?[\w\s-_]+\?B\?[^\?]+\?=\s*)+(<([\w-\.]+@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[\w-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?))>)*)+",
                            RegexOptions.IgnoreCase
                       );
                   if (temp2.Count > 0)
                   {
                       temp2
                           .OfType<Match>()
                           .Select
                           (x =>
                               {
                                   var captures =
                                       x.Groups[1]
                                       .Captures
                                       .OfType<Capture>();
                                   captures
                                       .Select
                                       (
                                            (y, index) =>
                                            {
                                                temp =
                                                    Regex
                                                    .Match
                                                    (
                                                        y.Value,
                                                        @"=\?([\w\s-_]+)\?B\?([^\?]+)\?=\s*",
                                                        RegexOptions.IgnoreCase
                                                    );
                                                
                                                string decodedStr = Encoding.GetEncoding(temp.Groups[1].Value).GetString(Convert.FromBase64String(temp.Groups[2].Value));
                                                return
                                                    tempStr =
                                                        tempStr
                                                        .Replace
                                                        (
                                                            y.Value,
                                                            decodedStr
                                                            .PadRight(x.Groups[2].Success && index == captures.Count() - 1 ? decodedStr.Length + 1 : 0)
                                                        );
                                            }
                                       )
                                       .ToList();
                                   
                                   if (x.Groups[2].Success)
                                       tempStr =
                                           tempStr
                                           .Replace(x.Groups[2].Value, x.Groups[3].Value);
                                   return
                                       tempStr;
                               }
                           )
                           .ToList();
                       fieldValue = tempStr;
                   }
                   else if (addressField)
                   {
                       temp =
                           Regex
                           .Match
                           (
                                tempStr,
                                @"(?:(""[^\r\n]+"")*\s*<[\w-\.]+@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[\w-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?)>)+",
                                RegexOptions.IgnoreCase
                           );
                       if (temp.Success)
                       {
                           fieldValue =
                                        Regex
                                        .Unescape
                                        (
                                            Regex
                                            .Replace
                                            (
                                                fieldValue,                                                
                                                @"(?<!\\)""",
                                                string.Empty,                                                
                                                RegexOptions.IgnoreCase
                                            )
                                        );
                           
                           Regex
                               .Matches
                               (
                                    fieldValue,
                                    @"(<([\w-\.]+@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[\w-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?))>)",
                                    RegexOptions.IgnoreCase
                               )
                               .OfType<Match>()
                               .Select
                               (
                                    x =>
                                    {
                                        return fieldValue =
                                            fieldValue
                                            .Replace(x.Groups[1].Value, x.Groups[2].Value);
                                    }
                               )
                               .ToList();
                       }
                   }
               }
           }           
           return fieldValue;
       }
