        private void gGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.Compare(gGridView1.CurrentCell.OwningColumn.Name, "CheckBoxColumn") == 0)
            {
                bool checkBoxStatus = Convert.ToBoolean(gGridView1.CurrentCell.EditedFormattedValue);
                //checkBoxStatus gives you whether checkbox cell value of selected row for the
                //"CheckBoxColumn" column value is checked or not. 
                if(checkBoxStatus)
                {
                    //write your code
                }
                else
                {
                   //write your code
                }
            }
        }
