      using Word = Microsoft.Office.Interop.Word;
      Word.Application wordApplication = new Word.Application();
     var path="fullpath of docuent"
                     wordApplication.Documents.Open(path);
                    wordApplication.Visible = true;
                    wordApplication.ActiveWindow.View.Type = WdViewType.wdWebView;
                    ;
