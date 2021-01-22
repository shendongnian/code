        for (int i = 0; i <= (this.GridView3.Rows.Count - 1); i++)
        {
            for (int j = 0; j <= (this.GridView3.Rows[i].Cells.Count - 1); j++)
            {
                Str = this.GridView3.Rows[i].Cells[j].Text.ToString();
                sWriter.Write(Str);
            }
        }
