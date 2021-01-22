    int theCellNumberWhatINeed = -1;
    for (int cellNumber = 0; cellNumber < GridView1.Rows[index].Cells.Count; cellNumber++)
    {
        foreach (Control ctrl in GridView1.Rows[index].Cells[cellNumber].Controls)
        {
            if (ctrl.ID == "aCheckBox") // or compare by clientid... etc
            {
                theCellNumberWhatINeed = cellNumber;
                break;
            }
        }
    }
    if (theCellNumberWhatINeed > -1)
    {
        // ...
    }
