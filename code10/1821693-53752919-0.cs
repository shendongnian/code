    public void CreatePart(Func<ReplacementMap, Dictionary<string, string>> getReplacementMap) {
        CreateTextPart("DefaultText.txt",
            (string text) => {
                var mapd = getReplacementMap(replacements);
                Regex regex = new Regex(string.Join("|", mapd.Keys.Select(x => Regex.Escape(x))));
                string replaced = regex.Replace(text, m => mapd[m.Value]);
                return replaced;
            }
        );
    }
