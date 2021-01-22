    using mshtml;
      private void button1_Click(object sender, EventArgs e)
        {
        webBrowser1.Refresh();
            Application.DoEvents();
            if (webBrowser1.Document != null)
            {
                
                IHTMLDocument2 document = webBrowser1.Document.DomDocument as IHTMLDocument2;
                if (document != null)
                {
                    IHTMLSelectionObject currentSelection = document.selection;
                    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                  
                    if (range != null)
                    {
                        String search = textBox1.Text;
                        if (search == "")
                        {
                            MessageBox.Show("not selected");                          
                        }
                        else
                        {
                        line1:
                            if ((range.findText(search)) && (range.htmlText != "span style='background-color: rgb(255, 255, 0);'>" + textBox1.Text + "</span>"))
                            {
                                range.select();
                                range.pasteHTML("<span style='background-color: rgb(255, 255, 0);'>" + textBox1.Text.ToLower() + "</span>");
                                goto line1;
                            }
                        }
                    }
                }
            }
          }
