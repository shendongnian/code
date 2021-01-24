    //models
    public enum SystemDocType
    {
        [Display(Name = "Other")]
        Unknown,
        [Display(Name = "Condominium Certification")]
        CondominiumCertification,
        [Display(Name = "Previous Fiscal Years Ending Income/Expense")]
        PrevYearsIncomeExpense,
        [Display(Name = "Reserve Study")]
        ReserveStudy
        //more
    }
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "System Doc Type")]
        public SystemDocType? SysDocType { get; set; }
        //more
    }
    //controller
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("condo/updatedoctype")]
    public async Task<ActionResult> UpdateDocType(FormCollection data, int itemid)
    {
        var docType = context.DocTypes.Where(t => t.Id == itemid).FirstOrDefault();
        if (docType != null)
        {
            string val = data["item:" + itemid.ToString() + ":name"];
            int sysType = int.Parse(data["item:" + itemid.ToString() + ":sysdoctype"]);
            docType.TypeName = val;
            docType.SysDocType = (SystemDocType)sysType;
            await context.SaveChangesAsync();
            return RedirectToAction("DocTypes");
        }
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    //.shtml (razor)
    @model IEnumerable<fhaApproved2.Models.DocumentType>
    @* more *@
    @foreach (var item in Model) {
        @Html.EnumDropDownListFor(m => item.SysDocType, 
                htmlAttributes: new { @class = "form-control", @Name = "item:" + @item.Id + ":sysdoctype" })
        <button class="btn btn-primary" type="submit" title="Update Document Type" formaction="/condo/updatedoctype" name="itemid" formmethod="post" value="@item.Id">
            <span class="glyphicon glyphicon-floppy-save"></span>
        </button>
    }
