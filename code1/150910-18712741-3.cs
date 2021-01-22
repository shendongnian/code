    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace IncludeExcludeFileEnumerator
    {
        public class IncludeExcludeFileEnumerator : IEnumerator<String>
        {
            private string excludeRegExPattern;
            private readonly Regex regexSeparateFilePath;
            private readonly Regex excludeRegex = null;
            private int currentPatternIndex;
            private IEnumerator<string> filesEnum;
            private IEnumerable<string> files;
            bool isNext = true;
            private readonly List<Tuple<string, string, SearchOption>> incPatternsList;
    
    
            public IncludeExcludeFileEnumerator(string baseDirectory, string includePattern, string excludePattern)
            {
                // Split comma separated string to array of include patterns
                var initIncludePatterns = includePattern.Split(',');
                regexSeparateFilePath = new Regex(@"(.*)[\\/]([^\\/]*$)", RegexOptions.Compiled);
    
                // Prepare include patterns
                incPatternsList = initIncludePatterns.ToList().ConvertAll(
                    (incPattern) =>
                    {
                        incPattern = incPattern.Trim();
                        var matches = regexSeparateFilePath.Matches(incPattern);
                        string pathPattern;
                        string filePattern;
                        if (matches.Count == 0)
                        {
                            pathPattern = "";
                            filePattern = incPattern;
                        }
                        else
                        {
                            pathPattern = matches[0].Groups[1].Value;
                            filePattern = matches[0].Groups[2].Value;
                        }
                        SearchOption searchOption = SearchOption.TopDirectoryOnly;
                        if (filePattern.Contains("**"))
                        {
                            filePattern = filePattern.Replace("**", "*");
                            searchOption = SearchOption.AllDirectories;
                        }
                        var fullPathPattern = Path.Combine(baseDirectory, pathPattern);
                        // Returns tuple {PathPattern, FilePattern, SearchOption}
                        return new Tuple<string, string, SearchOption>(fullPathPattern, filePattern, searchOption);
                    });
    
                // Prepare regular expression for exclude case (all in one, concatinated by (| - or) separator)
                if (!String.IsNullOrWhiteSpace(excludePattern))
                {
                    var excPatterns = excludePattern.Replace(".", @"\.");
                    excPatterns = excPatterns.Replace("*", ".*");
                    excludeRegExPattern = excPatterns.Replace(",", "|");
                    excludeRegex = new Regex(excludeRegExPattern, RegexOptions.Compiled);
                }
                Reset();
            }
    
            public string Current
            {
                get { return filesEnum.Current; }
            }
    
            public void Dispose()
            {
    
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return (Object)this.Current; }
            }
    
            public bool MoveNext()
            {
                do
                {
                    if (( filesEnum == null ) && (incPatternsList.Count < currentPatternIndex + 2))
                    {
                        return false;
                    }
                    if ((filesEnum == null) || (isNext == false))
                    {
                        var tuple = incPatternsList[++currentPatternIndex];
                        files = Directory.EnumerateFiles(tuple.Item1, tuple.Item2, tuple.Item3);
                        filesEnum = files.GetEnumerator();
                        isNext = true;
                    }
                    while (isNext)
                    {
                        isNext = filesEnum.MoveNext();
                        if (isNext) 
                        {
                            if (excludeRegex==null) return true;
                            if (!excludeRegex.Match(filesEnum.Current).Success) return true;
                            // else continue;
                        }
                        else
                        {
                            filesEnum = null;
                        }
                    }
                } while (true);
            }
    
            public void Reset()
            {
                currentPatternIndex = -1;
                filesEnum = null;
            }
        }
        public class IncludeExcludeFileEnumerable : IEnumerable<string>
        {
            private string baseDirectory;
            private string includePattern;
            private string excludePattern;
    
            public IncludeExcludeFileEnumerable(string baseDirectory, string includePattern, string excludePattern)
            {
                this.baseDirectory = baseDirectory;
                this.includePattern = includePattern;
                this.excludePattern = excludePattern;
            }
    
            public IEnumerator<string> GetEnumerator()
            {
                return new IncludeExcludeFileEnumerator(baseDirectory, includePattern, excludePattern);
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return (IEnumerator)this.GetEnumerator();
            }
        }
    }
