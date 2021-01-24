    public class ClaimVM
    {
        // will hold the selected category ID
        public Int16? CategoryID { get; set; }
    
        public List<ClaimHistoryModel> claimHistoryModel { get; set; }
        public List<CategoryModelDum> categoryModel { get; set; }
    }
    
    @Html.DropDownListFor(m => m.CategoryID, new SelectList(Model.categoryModel, "ID", "CategoryName"), "Select Category", new { @class = "ddlList" })
    // change here -------^^^^^^^^^^^^^^^^^
