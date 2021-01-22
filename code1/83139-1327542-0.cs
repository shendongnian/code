        using(TextWriter toText = File.CreateText(toOutFile))
        {
            toText.WriteLine("\t\t" + filenameText.Text);
            toText.WriteLine("\t\t" + directoryText.Text+"\n\n");
            foreach(DataGridViewRow row in serviceDataGrid.Rows)
            {
                toText.WriteLine(row.Cells[0].Value.ToString());
            }
        }
