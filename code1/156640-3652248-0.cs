     if (_view.Selection.IsEmpty)
            {
                return;
            }
            else
            {
                 string selectedText = _view.Selection.StreamSelectionSpan.GetText();
                MessageBox.Show(selectedText);
            }
