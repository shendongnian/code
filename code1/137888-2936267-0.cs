        XmlReader reader = XmlReader.Create("http://kwead.com/blog/?feed=atom");
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        reader.Close();
        foreach (SyndicationItem item in feed.Items)
        {
            string data = item.PublishDate.ToString();
            DateTime dt = Convert.ToDateTime(data);
            string titulo = " - " + item.Title.Text + "<br>";
            string conteudo = ((TextSyndicationContent)item.Content).Text;
            Response.Write(dt.ToString("d"));
            Response.Write(titulo);
            Response.Write(conteudo);
         }
