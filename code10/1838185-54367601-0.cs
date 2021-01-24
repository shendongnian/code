            List<int> indexesToDelete = new List<int>();
            dgv.Rows.Cast<DataGridViewRow>().ToList().ForEach(x =>
            {
                if (x.Cells[3].Value != null && (bool)x.Cells[3].Value != false)
                {
                    indexesToDelete.Add(x.Index);
                };
            });
            indexesToDelete.Reverse();
            indexesToDelete.ForEach(i => dgv.Rows.RemoveAt(i));
