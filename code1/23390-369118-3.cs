    public class Office
    {
        public string OfficeName {get;set;};
        List<string> _doctors = new List<string>();
        public List<string> Doctors {get{ return _doctors; } };
        void Clear()
        {
            OfficeName = "";
            _doctors.Clear();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("<tr>");
            result.AppendFormat("<td>{0}</td>", OfficeName);
      
            string delimiter = "";
            result.Append("<td>");
            foreach(string doctor in Doctors)
            {
               result.Append(doctor).Append(delimiter);
               delimiter = "<br/>";
            }
        
            result.Append("</td></tr>");
            return result.ToString();
        }
    }
. 
    private string CurOffice = "";
    private Office CurRecord = new Office();
    void NextItem(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
        Literal repeaterRow = e.Item.FindControl("RepeaterRow") as Literal;
        if (repeaterRow == null) return;
        DataRow row = ((DataRowView)e.Item.DataItem).Row;
        if ( CurOffice != (string)row["Office"] )
        {
            repeaterRow.Text = CurRecord.ToString();
            repeaterRow.Visible = true;
            CurRecord.Clear();
            CurOffice = row["Office"];
            CurRecord.Office = CurOffice;
        }
        else
            e.Item.Visible = false;
        CurRecord.Doctors.Add((string)row["doctor"]);
    }
    void Page_PreRender(object sender, EventArgs e)
    {
        LastRow.Text = CurRecord.ToString();
    }
    
