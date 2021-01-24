    [HttpPost]
        public ActionResult EditCP(Tuple<CommunityParkletDashboard.Models.COMMUNITY_PARKLET_APPLICATION, CommunityParkletDashboard.ViewModels.CPDashboardModel> cpa, int id)
        {
            _context.UpdateParkletApplication(cpa, id);
            return RedirectToAction("CPDashboard");
        }
