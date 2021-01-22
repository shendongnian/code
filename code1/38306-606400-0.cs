    private void mainRTB_TextChanged(object sender, TextChangedEventArgs e)  {
                TextRange text = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
                if (text.Text.Length >= this.MaxLenght && mainRTB.CanUndo)
                {
                    mainRTB.Undo();
                    mainRTB.IsReadOnly = true;
                }
    }
