        internal class InputCheckBoxField : CheckBoxField
        {
            //... Some boilerplate for ID and other properties here
            protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
            {
                base.InitializeDataCell(cell, rowState);
                if (cell.Controls.Count == 0)
                {
                    CheckBox chk = new CheckBox();
                    chk.ID = CheckBoxID;
                    chk.AutoPostBack = true;
                    cell.Controls.Add(chk);
                    //This was the needed check
                    if(ReadOnly && rowState == DataControlRowState.Edit)
                        chk.Enabled = false;
                }
            }
        }
