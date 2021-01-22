    public ActionResult returnJSON(string filter)
        {
            DataTable table = FindDataWhere(filter);
            var data = new List<Dictionary<string, string>>();
            foreach (DataRow row in table.Rows)
            {
                var foo = new Dictionary<string, string>();
                location.Add("Col1", (string)row["Col1"]);
                location.Add("Col2", (string)row["Col2"]);
                location.Add("Col3", (string)row["Col3"]);
                data.Add(foo);
            }
            return Json(data);
        }
