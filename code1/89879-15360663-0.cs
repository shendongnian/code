     public static class StringProcessor
    {
        private static List<String> PrepositionList;
        public static string ToNormalString(this string strText)
        {
            if (String.IsNullOrEmpty(strText)) return String.Empty;
            char chNormalKaf = (char)1603;
            char chNormalYah = (char)1610;
            char chNonNormalKaf = (char)1705;
            char chNonNormalYah = (char)1740;
            string result = strText.Replace(chNonNormalKaf, chNormalKaf);
            result = result.Replace(chNonNormalYah, chNormalYah);
            return result;
        }
        public static List<KeyValuePair<String, Int32>> Process(this String bodyText,
            List<String> blackListWords = null,
            int minimumWordLength = 3,
            char splitor = ' ',
            bool perWordIsLowerCase = true)
        {
            string[] btArray = bodyText.ToNormalString().Split(splitor);
            long numberOfWords = btArray.LongLength;
            Dictionary<String, Int32> wordsDic = new Dictionary<String, Int32>(1);
            foreach (string word in btArray)
            {
                if (word != null)
                {
                    string lowerWord = word;
                    if (perWordIsLowerCase)
                        lowerWord = word.ToLower();
                    var normalWord = lowerWord.Replace(".", "").Replace("(", "").Replace(")", "")
                        .Replace("?", "").Replace("!", "").Replace(",", "")
                        .Replace("<br>", "").Replace(":", "").Replace(";", "")
                        .Replace("،", "").Replace("-", "").Replace("\n", "").Trim();
                    if ((normalWord.Length > minimumWordLength && !normalWord.IsMemberOfBlackListWords(blackListWords)))
                    {
                        if (wordsDic.ContainsKey(normalWord))
                        {
                            var cnt = wordsDic[normalWord];
                            wordsDic[normalWord] = ++cnt;
                        }
                        else
                        {
                            wordsDic.Add(normalWord, 1);
                        }
                    }
                }
            }
            List<KeyValuePair<String, Int32>> keywords = wordsDic.ToList();
            return keywords;
        }
        public static List<KeyValuePair<String, Int32>> OrderByDescending(this List<KeyValuePair<String, Int32>> list, bool isBasedOnFrequency = true)
        {
            List<KeyValuePair<String, Int32>> result = null;
            if (isBasedOnFrequency)
                result = list.OrderByDescending(q => q.Value).ToList();
            else
                result = list.OrderByDescending(q => q.Key).ToList();
            return result;
        }
        public static List<KeyValuePair<String, Int32>> TakeTop(this List<KeyValuePair<String, Int32>> list, Int32 n = 10)
        {
            List<KeyValuePair<String, Int32>> result = list.Take(n).ToList();
            return result;
        }
        public static List<String> GetWords(this List<KeyValuePair<String, Int32>> list)
        {
            List<String> result = new List<String>();
            foreach (var item in list)
            {
                result.Add(item.Key);
            }
            return result;
        }
        public static List<Int32> GetFrequency(this List<KeyValuePair<String, Int32>> list)
        {
            List<Int32> result = new List<Int32>();
            foreach (var item in list)
            {
                result.Add(item.Value);
            }
            return result;
        }
        public static String AsString<T>(this List<T> list, string seprator = ", ")
        {
            String result = string.Empty;
            foreach (var item in list)
            {
                result += string.Format("{0}{1}", item, seprator);
            }
            return result;
        }
        private static bool IsMemberOfBlackListWords(this String word, List<String> blackListWords)
        {
            bool result = false;
            if (blackListWords == null) return false;
            foreach (var w in blackListWords)
            {
                if (w.ToNormalString().Equals(word))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
