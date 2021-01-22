    public string ShortCode
        {
            get { return Distance + Carriageway; }
        }
    
    private void UpdateMapRoadPointList(List<GeographicAddress> plstMapRoadPointList)
        {
            cboFind.DataSource = plstMapRoadPointList;
            cboFind.DisplayMember = "ShortCode";
        }
