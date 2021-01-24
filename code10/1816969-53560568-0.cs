    public class SaveResponseModel
        {
            public int SubSectionID { get; set; }
            public int QuestionID { get; set; }
            public bool Response { get; set; }
        }
    [HttpPost]
        public ActionResult SaveResponsesData(List<SaveResponseModel> responses)
        {
            // ViewBag.SelectedType = TypeValue.ToUpper();
            return View();
        }
