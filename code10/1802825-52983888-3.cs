            [LEMClaimAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus })]
        public ActionResult One()
        {
            return View();
        }
        [LEMClaimAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus }, new EEntity[] { EEntity.JobTool })]
        public ActionResult Two()
        {
            return View();
        }
