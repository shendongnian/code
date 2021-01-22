            try
            {
                List<Qualification> qualifications = Qualification.Load(this.groupBonus.PlanID, this.ConnectionString);
                foreach (Qualification qual in qualifications)
                {
                    DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)this.dataGridSplitVolumes.Columns[0];
                    col.Items.Add(qual);                    
                }
                SplitVolumeGrid_QualificationColumn.ValueMember = "Name";
            }
            catch (Exception ex)
            {
