    public void GetSelection(List<Person> result)
    {
        var rows = dataGridView1.SelectedRows;
        for(int i = 0; i < rows.Count; i++)
        {
            Person p = rows[i].DataBoundItem as Person;
            if (p != null)
                result.Add(p);
        }
    }
