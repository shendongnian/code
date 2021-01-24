    public ActionResult Index(FilterPostedJob objFilterPostedJob, int? page)
        {
            Result res = null;
            try
            {
                objFilterPostedJob.CreatedBy = ApplicationSession.CurrentUser.RecruiterId;
                objFilterPostedJob.page = (objFilterPostedJob.page == null ? 1 : objFilterPostedJob.page);
                ViewBag.SearchPostedJob = objFilterPostedJob;
                res = objPostedJobDAL.GetPostedJobs(objFilterPostedJob);
                int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(((List<PostedJob>)res.Results).ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Common.WriteLog(ex);
                throw ex;
            }          
        }
