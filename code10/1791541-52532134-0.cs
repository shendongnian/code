    private List<string> AddAllGrades()
        {
        foreach (RadioButton rad in groupBox1.Controls)
                    {
                        if (rad.Checked)
                            allGrades.Add(rad.Text);
                    }
                    return allGrades;
        }
