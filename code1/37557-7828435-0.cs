        // user clicks on button, which binds the dg to the datatable,
        // prompts the user to save the XML, serializes it and saves the file.
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dg.DataSource = dtResults; // this actually happens earlier.
            _dtResults = dtResults; // this actually happens earlier.
            if (dg.Columns.Count > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportXMLFromDG(saveFileDialog1.FileName);
                }
            }
        }
        private void ExportXMLFromDG(string xml_file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            TextWriter textWriter = new StreamWriter(xml_file);
            serializer.Serialize(textWriter, _dtResults);
            textWriter.Close();
        }
