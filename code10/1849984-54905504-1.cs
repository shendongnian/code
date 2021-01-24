    [HttpPost]
    public async Task<ActionResult> CheckExistingDocumentCode(string DocumentCode, int DocumentId)
    {
        try
        {
            if (!await _documentValidationRules.IsExistingDocumentCodeAsync(DocumentCode, DocumentId))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("This Document Code is already in use", JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
