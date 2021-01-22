                using (IE ie = new IE("http://www.google.co.il"))
                {
                    ie.TextField(Find.ByName("q")).TypeText(keyword);
                    ie.Button(Find.ByName("btnG")).Click();
                    int position = 1;
                    label1.Text = "";
                    foreach (Span span in ie.Spans)
                    {
                        if (span.OuterHtml.ToLower().StartsWith("<span dir=ltr>"))
                        {
                            label1.Text += position.ToString() + ": " + span.InnerHtml + "\n";
                            position++;
                        }
                    }
                }
