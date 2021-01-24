        void remove_underline()
        {
                Word.Range range;
                range = Application.ActiveDocument.Content;
                remove_underline(range, 254);
                remove_underline(range, 32769);
                remove_underline(range, 16711681);
        }
        void remove_underline(Word.Range range, int colorIndex) {
            range.Find.ClearFormatting();
            range.Find.Replacement.ClearFormatting();
            range.Find.Text = "";
            range.Find.Font.UnderlineColor = (Word.WdColor)colorIndex;
            range.Find.Font.Underline = Word.WdUnderline.wdUnderlineWavy;
            range.Find.Replacement.Text = "";
            range.Find.Replacement.Font.Underline = Word.WdUnderline.wdUnderlineNone;
            range.Find.Execute(Format: true,Replace:Word.WdReplace.wdReplaceAll);
        }
