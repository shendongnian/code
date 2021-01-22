    protected override void Render(HtmlTextWriter writer)
        {
             if (!Page.IsPostBack)
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(stream))
                    {
                        HtmlTextWriter htmlWriter = new HtmlTextWriter(streamWriter);
                        base.Render(htmlWriter);
                        htmlWriter.Flush();
                        stream.Position = 0;
                        using (System.IO.StreamReader oReader = new System.IO.StreamReader(stream))
                        {
                            string pageContent = oReader.ReadToEnd();
                            pageContent = ParseTagsFromPage(pageContent);
                            writer.Write(pageContent);
                            oReader.Close();
                        }
                    }
                }
            }
            else
            {
                base.Render(writer);
            }
        }
