    public ActionResult GetPages()
            {
                int currentPage = 1; string search = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    currentPage = Convert.ToInt32(Request.QueryString["page"]);
                }
    
                if (!string.IsNullOrEmpty(Request.QueryString["q"]))
                {
                    search = "&q=" + Request.QueryString["q"];
                }
    
                /* to be Fetched from database using count */
                int recordCount = 100;
    
                Place place = new Place();
                Pagination pagination = place.GetCategoryPaging(currentPage, recordCount, search);
    
                return PartialView("Controls/_Pagination", pagination);
            }
    
