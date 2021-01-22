    public class Thing
    {
        public string id{  get ;  set ; }
        public string Name  {  get ;  set ; }
        //self ref
        public Thing This
        {
            get { return this; }
        }
    }
    form_load(){
          comboboxcell.ValueMember = "This";  // self ref
          comboboxcell.DisplayMember = "Name";
    }
     datagridview1.CellValueChanged += (s, e) => {
        var cb = (DataGridViewComboBoxCell)dgv_titles.Rows[e.RowIndex].Cells[e.ColumnIndex];
       var selectedObject  = (Thing)cb.Value  ;
    }
