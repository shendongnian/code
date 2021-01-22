        [HttpPost]
        [JsonFilter(Param = "commissions", JsonDataType = typeof(List<CommissionsJs>))]
        public ActionResult SubmitCommissions(List<CommissionsJs> commissions)
        {
            var result = dosomething(commissions);
            var jsonData = new
            {
                Result = true,
                Message = "Success"
            };
            if (result < 1)
            {
                jsonData = new
                {
                    Result = false,
                    Message = "Problem"
                };
            }
            return Json(jsonData);
        }
