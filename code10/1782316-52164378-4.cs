        using (StreamReader sr = new StreamReader(bs))
        {
            Parallel.ForEach(sr.ReadToEnd(), i=>
            {
                stringBuilder.Append(i);
            });
            wordDoc.Content.Text = stringBuilder.ToString();
            wordDoc.SaveAs(path + "\\big3.docx");
        }
