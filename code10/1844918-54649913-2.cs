    public class ColorArticle
    {
        public string color { get; set; }
        public string article { get; set; }
    }
    public void SetChoice()
    {
        ColorArticle colorArticle = new ColorArticle() { color = "Rouge", article = "chaise" };
        Dictionary<ColorArticle, string> listChoice = new Dictionary<ColorArticle, string>
        {
            { colorArticle, "350,25" }
        };
    }
