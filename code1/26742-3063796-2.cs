        [Test]
        public void MeasureStripPunctionationTest()
        {
            Measure("stringbuilder with foreach", s =>
                                                      {
                                                          var sb = new StringBuilder();
                                                          foreach (char c in s)
                                                          {
                                                              if (!char.IsPunctuation(c))
                                                                  sb.Append(c);
                                                          }
                                                          return sb.ToString();
                                                      });
            Measure("stringbuilder with foreach wrapped in extension", s =>
                                                                           {
                                                                               var sb = new StringBuilder();
                                                                               foreach (char c in s)
                                                                               {
                                                                                   if (!char.IsPunctuation(c))
                                                                                       sb.Append(c);
                                                                               }
                                                                               return sb.ToString();
                                                                           });
            Measure("stringbuilder with for", s =>
                                                  {
                                                      var sb = new StringBuilder();
                                                      for (int i = 0; i < s.Length; i++)
                                                      {
                                                          if (!char.IsPunctuation(s[i]))
                                                              sb.Append(s[i]);
                                                      }
                                                      return sb.ToString();
                                                  });
            Measure("string concat with foreach", s =>
                                                      {
                                                          var result = "";
                                                          foreach (char c in s)
                                                          {
                                                              if (!char.IsPunctuation(c))
                                                                  result += c;
                                                          }
                                                          return result;
                                                      });
            Measure("where with new string", s => new string(s.Where(item => !char.IsPunctuation(item)).ToArray()));
            Measure("where with aggregate", s => s.Where(item => !char.IsPunctuation(item))
                                                     .Aggregate(string.Empty, (result, c) => result + c));
            var stripRegex = new Regex(@"\p{P}+", RegexOptions.Compiled);
            Measure("compiled regex", s => stripRegex.Replace(s, ""));
        }
        private void Measure(string name, Func<string, string> stripPunctation)
        {
            using (new PerformanceTimer(name))
            {
                var s = "a !@#$ short >{}*' string";
                for (int i = 0; i < 1000000; i++)
                {
                    var withoutPunctuation = stripPunctation(s);
                }
            }
        }
