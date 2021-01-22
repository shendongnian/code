        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetGridCell(double longitude, double latitude, FormCollection collection)
        {
            var cell = new GridCellViewModel { X = (int)Math.Round(longitude), Y = (int)Math.Round(latitude) };
            return Json(cell);
        }
