        for (int index = 0; index < dataGridView1.Columns.Count; index++) {
            foreach (DataGridViewColumn c in dataGridView1.Columns) {
                if (c.DisplayIndex == index) {
                    // You've got your next column.
                    Console.WriteLine(c.Name);
                }
            }
        }
