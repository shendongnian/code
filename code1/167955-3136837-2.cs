        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetGridCell(double longitude, double latitude)
        {
            var cell = new GridCellViewModel { X = (int)Math.Round(longitude), Y = (int)Math.Round(latitude) };
            return Json(cell);
        }
