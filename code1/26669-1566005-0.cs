        public void InitForm()
        {
            bnsEntity.DataSource = CacheManagement.cachedAreas;
            newID = CacheManagement.cachedAreas.LastOrDefault().areaID + 1;
            grdEntity.DataSource = bnsEntity;
        }
'''
        private void tsbNew_Click(object sender, EventArgs e)
        {
            var newArea = new Area();
            newArea.areaID = (byte)newID++;
            dataContext.GetTable<Area>().InsertOnSubmit(newArea);
            bnsEntity.Add(newArea);
            grdEntity.MoveToNewRecord();
        }
