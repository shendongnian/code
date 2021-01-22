    public class TextArticle : ContentEntryBase
    {
        public override void ShowEditor ()
        {
            var editor = new FrmTextEditor (this);
            editor.ShowDialog();
        }
    }
