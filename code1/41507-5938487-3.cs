    /// <summary>
    /// Populate the dataGridSplitVolumes data grid with all existing qualifications for the plan.
    /// </summary>
    /// <param name="bonus"></param>
    private void PopulateDataGridSplitVolumes(Bonus_Group bonus)
    {
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
    #if DEBUG
        System.Diagnostics.Debugger.Break();
    #endif
        throw ex;
      }
    }//PopulateDataGridSplitVolumes     
