        public DataTable getDataTable( CheckBox yourCheckBox)
        {
            DataTable returnTable = new DataTable();
            List<string> tempList = new List<string>();
            var checkedDesignStatus = yourCheckBox.CheckBoxItems.Where(x => x.Checked);
            foreach (var i in checkedDesignStatus)
            {
                tempList.Add(i.Text);
            }
            returnTable = ToStringDataTable(tempList);
            return returnTable;
        }
