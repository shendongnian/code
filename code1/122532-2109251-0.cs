    DestTableAdapter destTableAdapter = new DestTableAdapter();
    MissioniDataSet.DestDataTable destDataTable =
               destTableAdapter.GetDataByMissioneID(MissioneID);
    for(int i = 0; i < destDataTable.Rows.Count; i++)
    {
        destRow = (MissioniDataSet.DestRow)destDataTable.Rows[i];
        destRow.AccontoMax = i;
    }
    destTableAdapter.Update(destDataTable);
