     private void saveToolStripMenuItem_Click(object sender, EventArgs e)
     {
         saveFileDialog1.Title = "Save Song File";
         saveFileDialog1.Filter = "Song Files|*.xsong";
         if (saveFileDialog1.ShowDialog() == DialogResult.OK)
         {
             FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
             XmlTextWriter w = new XmlTextWriter(fs, Encoding.UTF8);
             w.WriteStartDocument();
             w.WriteStartElement("music");
             w.WriteAttributeString("judul", Program.music.getTitle());
             w.WriteAttributeString("pengarang", Program.music.getAuthor());
             w.WriteAttributeString("tempo", Program.music.getTempo()+"");
             w.WriteAttributeString("birama", Program.music.getBirama());
             w.WriteAttributeString("nadadasar", Program.music.getNadaDasar());
             w.WriteAttributeString("biramapembilang", Program.music.getBiramaPembilang()+"");
             w.WriteAttributeString("biramapenyebut", Program.music.getBiramaPenyebut()+"");
             for (int i = 0; i < listNotasi.Count; i++)
             {
                 CNot not = listNotasi[i];
                 w.WriteStartElement("not");
                 w.WriteAttributeString("angka", not.getNot() + "");
                 w.WriteAttributeString("oktaf", not.getOktaf() + "");
                 String naikturun="";
                 if(not.isTurunSetengah())naikturun="\\";
                 else if(not.isNaikSetengah())naikturun="/";
                 w.WriteAttributeString("naikturun",naikturun);
                 w.WriteAttributeString("nilai", not.getNilaiNot()+"");
                 w.WriteEndElement();
             }
             w.WriteEndElement();
             w.Flush();
             fs.Close();
         }
     }
