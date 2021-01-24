    public ActionResult INTImportData()
    {
        if (Session["UserLogon"] != null)
        {
            BLINTForms objForm = new BLINTForms();
            objDCFormList = new DCFormList();
            int jobId = Session["Job_ID"] == null ? 0 : (int)Session["Job_ID"];
            ViewBag.jobId = jobId;
            objDCFormList.Form = objForm.GetINTFormTempDataByJobId(jobId);
            TempData["DCFormList"] = objDCFormList.Form;
            Response.StatusCode = (int)HttpStatusCode.OK;
            return View(objDCFormList.Form);
        }
        else
            return Redirect("~/Account/Login");
    }
