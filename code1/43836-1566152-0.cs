        public void InitForm()
        {
            'cachedAreas is a List<Area> created from dataContext.Areas.ToList()
            bnsEntity.DataSource = cachedAreas;
            'A nominal ID
            newID = cachedAreas.LastOrDefault().areaID + 1;
            grdEntity.DataSource = bnsEntity;
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            var newArea = new Area();
            newArea.areaID = (byte)newID++;
            dataContext.GetTable<Area>().InsertOnSubmit(newArea);
            bnsEntity.Add(newArea);
            grdEntity.MoveToNewRecord();
        }
