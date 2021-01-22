    public virtual ActionResult RedirectTo(string url1, string url2, string url3)
        {
            if (string.IsNullOrEmpty(url1)) return Home();
            var pageModel = new PageModel();
            pageModel.CurrentPage = _pageRepo.GetByUrl(url1, url2, url3);
            BuildMenusAndBreadCrumb(pageModel);
            ViewData.Model = pageModel;
            return View(Views.Index);
        }
