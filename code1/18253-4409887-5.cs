    openFileDialog1.Title = "Open Song File";
    openFileDialog1.Filter = "Song Files|*.xsong";
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
        XmlTextReader r = new XmlTextReader(fs);
        while (r.Read())
        {
            if (r.NodeType == XmlNodeType.Element)
            {
                if (r.Name.ToLower().Equals("music"))
                {
                    Program.music = new CMusic(r.GetAttribute("judul"),
                        r.GetAttribute("pengarang"),
                        r.GetAttribute("birama"),
                        Convert.ToInt32(r.GetAttribute("tempo")),
                        r.GetAttribute("nadadasar"),
                        Convert.ToInt32(r.GetAttribute("biramapembilang")),
                        Convert.ToInt32(r.GetAttribute("biramapenyebut")));
                }
                else
                    if (r.Name.ToLower().Equals("not"))
                    {
                        CNot not = new CNot(Convert.ToInt32(r.GetAttribute("angka")), Convert.ToInt32(r.GetAttribute("oktaf")));
                        if (r.GetAttribute("naikturun").Equals("/"))
                        {
                            not.setNaikSetengah();
                        }
                        else if (r.GetAttribute("naikturun").Equals("\\"))
                        {
                            not.setTurunSetengah();
                        }
                        not.setNilaiNot(Convert.ToSingle(r.GetAttribute("nilai")));
                        listNotasi.Add(not);
                    }
            }
            else
                if (r.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine("\tVALUE: " + r.Value);
                }
        }
    }
    }
    }
