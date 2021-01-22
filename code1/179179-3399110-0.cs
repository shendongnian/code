    var querySpecification = new QuerySpecification();
    if (!string.IsNullOrEmpty(this.txtSubject.Text.Trim()))
    {
         querySpecification = new WhereSubject().Is(txtSubject);
    }
    else if (!string.IsNullOrEmpty(this.fromDate.Text.Trim()))
    {
         querySpecification = new WhereFromDate().Is(fromDate);
    }
    else
    {
         querySpecification = new All();
    }
    e.Result = reporterRepo.GetInquiries(querySpecification);
