List&lt;Control&gt; childControls = Misc.Misc.GetAllChildControls(this);
foreach (Control ctrl in childControls) {
    if (ctrl is WorksheetGridView) {
         WorksheetGridView wsgv = ctrl as WorksheetGridView;
         wsgv.BindData();
    }
}
