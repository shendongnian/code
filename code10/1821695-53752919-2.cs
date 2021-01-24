    public void CreatePart(Dictionary<string, string> mapd) {
        CreateTextPart("DefaultText.txt",
            (string text) => {
                Regex regex = new Regex(string.Join("|", mapd.Keys.Select(x => Regex.Escape(x))));
                string replaced = regex.Replace(text, m => mapd[m.Value]);
                return replaced;
            }
        );
    }
    public void CreateTextFile() {
        CreatePart(replacements.DefaultText());
        CreatePart(replacements.RedText());
        CreatePart(replacements.EndText());
    }
