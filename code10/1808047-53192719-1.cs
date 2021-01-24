    public async Task<ActionResult> Dashboard(int Report_Num)
        {
           
            var ticket = "";
            //Get Trusted Tableau Authentication Ticket
            try
            {
                ticket = await _trustedAuth.requestTicket(b.getSSO(User.Identity.Name), ConfigurationManager.AppSettings["TrustedAuthTableauServer"], ConfigurationManager.AppSettings["TrustedAuthSiteName"]);
            }
            catch
            {
                ticket = "-1";
            }
            //Only add trusted Tableau Authentication ticket if it's valid, else kick user to default Report_Link which will make them login manually. 
            //You get a nasty error message if you pass in a '-1'
            if (!ticket.Equals("-1"))
            {
                ViewBag.Link = _trustedAuth.addTicket(ticket.ToString(), report_Completion_Status.Report_Link);
            }
            else
            {
                ViewBag.Link = report_Completion_Status.Report_Link;
            }
            var model = await this.GetFullAndPartialViewModel(Report_Num);
            return this.View(model);
        }
