        #region Override - OnApplyTemplate
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.PART_ListViewLeft      = GetTemplateChild(cPART_ListViewLeft)      as ListView;
            this.PART_ListViewCenter    = GetTemplateChild(cPART_ListViewCenter)    as ListView;
            this.PART_ListViewRight     = GetTemplateChild(cPART_ListViewRight)     as ListView;
            this.PART_GridViewLeft      = GetTemplateChild(cPART_GridViewLeft)      as DsxGridView;
            this.PART_GridViewCenter    = GetTemplateChild(cPART_GridViewCenter)    as DsxGridView;
            this.PART_GridViewRight     = GetTemplateChild(cPART_GridViewRight)     as DsxGridView;
            if(this.PART_ListViewLeft!=null)
                this.PART_ListViewLeft      .AlternationCount = this.AlternatingRowBrushes.Count;
            if(this.PART_ListViewCenter!=null)
                this.PART_ListViewCenter    .AlternationCount = this.AlternatingRowBrushes.Count;
            if(this.PART_ListViewRight!=null)
                this.PART_ListViewRight     .AlternationCount = this.AlternatingRowBrushes.Count;
          //  ApplyTempleted = true;
            CreateColumnLayout();
        }
        #endregion
