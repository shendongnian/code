        /// <summary>
        /// the ultimate Path combiner of all time
        /// </summary>
        /// <param name="IsURL">
        /// true - if the paths are internet urls,false - if the paths are local urls,this is very important as this will be used to decide which separator will be used
        /// </param>
        /// <param name="IsRelative">just adds the separator at the beginning</param>
        /// <param name="IsFixInternal">fix the paths from within (by removing duplicate separators and correcting the separators)</param>
        /// <param name="parts">the paths to combine</param>
        /// <returns>the combined path</returns>
        public static string PathCombine(bool IsURL , bool IsRelative , bool IsFixInternal , params string[] parts)
        {
            if (parts == null || parts.Length == 0) return string.Empty;
            char separator = IsURL ? '/' : '\\';
            if (parts.Length == 1 && IsFixInternal)
            {
                string validsingle;
                if (IsURL)
                {
                    validsingle = parts[0].Replace('\\' , '/');
                }
                else
                {
                    validsingle = parts[0].Replace('/' , '\\');
                }
                validsingle = validsingle.Trim(separator);
                return (IsRelative ? separator.ToString() : string.Empty) + validsingle;
            }
            string final = parts
                .Aggregate
                (
                (string first , string second) =>
                {
                    string validfirst;
                    string validsecond;
                    if (IsURL)
                    {
                        validfirst = first.Replace('\\' , '/');
                        validsecond = second.Replace('\\' , '/');
                    }
                    else
                    {
                        validfirst = first.Replace('/' , '\\');
                        validsecond = second.Replace('/' , '\\');
                    }
                    var prefix = string.Empty;
                    if (IsFixInternal)
                    {
                        if (IsURL)
                        {
                            if (validfirst.Contains("://"))
                            {
                                var tofix = validfirst.Substring(validfirst.IndexOf("://") + 3);
                                prefix = validfirst.Replace(tofix , string.Empty).TrimStart(separator);
                                var tofixlist = tofix.Split(new[] { separator } , StringSplitOptions.RemoveEmptyEntries);
                                validfirst = separator + string.Join(separator.ToString() , tofixlist);
                            }
                            else
                            {
                                var firstlist = validfirst.Split(new[] { separator } , StringSplitOptions.RemoveEmptyEntries);
                                validfirst = string.Join(separator.ToString() , firstlist);
                            }
                            var secondlist = validsecond.Split(new[] { separator } , StringSplitOptions.RemoveEmptyEntries);
                            validsecond = string.Join(separator.ToString() , secondlist);
                        }
                        else
                        {
                            var firstlist = validfirst.Split(new[] { separator } , StringSplitOptions.RemoveEmptyEntries);
                            var secondlist = validsecond.Split(new[] { separator } , StringSplitOptions.RemoveEmptyEntries);
                            validfirst = string.Join(separator.ToString() , firstlist);
                            validsecond = string.Join(separator.ToString() , secondlist);
                        }
                    }
                    return prefix + validfirst.Trim(separator) + separator + validsecond.Trim(separator);
                }
                );
            return (IsRelative ? separator.ToString() : string.Empty) + final;
        }
