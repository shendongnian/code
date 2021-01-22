            WORD_APP = Globals.ThisAddIn.Application;
            object oMissing = System.Reflection.Missing.Value;
            object oTemplate = "E:\\Sandbox\\TemplateWithFields\\TemplateWithFields\\TemplateWithFields.dotx";
            Word.Document document = WORD_APP.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
            //Iterate through ALL content controls
            //Display text only if the content control is of type rich text
            foreach (Word.ContentControl contentControl in document.ContentControls)
            {
                if (contentControl.Type == Word.WdContentControlType.wdContentControlRichText)
                {
                    System.Windows.Forms.MessageBox.Show(contentControl.Range.Text);
                }
            }
            //Only iterate through content controls where the tag is equal to "RT_Controls"
            foreach (Word.ContentControl contentControl in document.SelectContentControlsByTag("RT_Controls"))
            {
                if (contentControl.Type == Word.WdContentControlType.wdContentControlRichText)
                {
                    System.Windows.Forms.MessageBox.Show("Selected by tag - " + contentControl.Range.Text);
                }
            }
            //Only iterate through content controls where the title is equal to "Title1"
            foreach (Word.ContentControl contentControl in document.SelectContentControlsByTitle("Title1"))
            {
                if (contentControl.Type == Word.WdContentControlType.wdContentControlRichText)
                {
                    System.Windows.Forms.MessageBox.Show("Selected by title - " + contentControl.Range.Text);
                }
            }
