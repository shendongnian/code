    public class TArticle
    {
        public string Text { get; set; }
        public int FKArticle { get; set; }
    
        public override string ToString()
        {
            return Text;
        }
    }
    private void InitTArticleComboBox()
    {
        TArticle item = new TArticle()
        {
            Text = "Article1",
            Value = 11
        };
    
        comboBox_Article.Items.Add(item);
        comboBox_Article.SelectedIndex = 0;
    }
