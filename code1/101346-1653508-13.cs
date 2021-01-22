        //
        // POST: /Announcements/UploadPdfToAnnouncement/ID
        [KsisAuthorize(Roles = "Admin, Announcements")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadPdfToAnnouncement(int ID)
        {
            FileManagerController.FileUploadResultDTO files =
                FileManagerController.GetFilesFromRequest((HttpContextWrapper)HttpContext);
            if (String.IsNullOrEmpty(files.ErrorMessage) && files.TotalBytes > 0)
            {
                // add SINGLE file to the announcement
                try
                {
                    this._svc.AddAnnouncementPdfDoc(
                        this._svc.GetAnnouncementByID(ID),
                        new PdfDoc(files.Files[0]),
                        new User() { UserName = User.Identity.Name });
                }
                catch (ServiceExceptions.KsisServiceException ex)
                {
                    // only handle our exceptions
                    base.AddErrorMessageLine(ex.Message);
                }
            }
            // redirect back to detail page
            return RedirectToAction("Detail", "Announcements", new { id = ID });
        }
