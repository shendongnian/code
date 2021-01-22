    private String longestCommonWord(String s1, String s2)
        {
            String[] seperators = new String[] { " ", ",", ".", "!", "?", ";" };
            var result = from w1 in s1.Split(seperators, StringSplitOptions.RemoveEmptyEntries)
                         where (from w2 in s2.Split(seperators, StringSplitOptions.RemoveEmptyEntries)
                                where w2 == w1
                                select w2).Count() > 0
                         orderby w1.Length descending
                         select w1;
            if (result.Count() > 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }
