            FileInfo fi = new FileInfo(Server.MapPath("~/Playlists/" + user + "/" + ListBox1.SelectedItem.Text  + ".wpl"));
            XmlDocument originalXML = new XmlDocument();
            originalXML.Load(fi.FullName);
            XmlWriter newXML = XmlWriter.Create(Server.MapPath("~/Playlists/" + user + "/" + ListBox1.SelectedItem.Text + ".wpl"));
            XmlNode smil = originalXML.SelectSingleNode("smil/body/seq");
            XmlNode media = originalXML.CreateNode(XmlNodeType.Element, "media", null);
            XmlAttribute src = originalXML.CreateAttribute("src");
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~" + folder));
            
            
            foreach (FileInfo file in di.GetFiles("*", SearchOption.AllDirectories))
            {
                string path = file.FullName;
                path = path.Replace(@"F:\Music\Music by Artist", "http://bgab-mor01-n/Music");
                path = path.Replace(@"\", "/");
                path = path.Replace(",", "");
                path = path.Replace("'", "");
                path = path.Replace("&", "");
                if (file.Extension == ".mp3" || file.Extension == ".wma" || file.Extension == ".MP3")
                {
                    src.Value = path;
                    media.Attributes.Append(src);
                    smil.AppendChild(media);
                }
            }
            
            originalXML.Save(newXML);
            newXML.Close();
