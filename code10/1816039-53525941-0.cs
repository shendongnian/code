    public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Currency  { get; set; }
        }
    
    private List<Test> Data()
            {
                var data = new List<Test>
                {
                    new Test{ Id = 1, Name = "A1", Currency = 1000000.00M},
                    new Test{ Id = 2, Name = "A2", Currency= 50000000.12M},
                    new Test{ Id = 3, Name = "A3", Currency = 3000000.45M},
                    new Test{ Id = 4, Name = "A4", Currency = 20000}
                };
                return data;
            }
    
            [HttpPost]
            public JsonResult LoadDataTables()
            {
                var data = Data();
                var recordsTotal = Data().Count;
                var recordsFiltered = Data().Count();
                string draw = Request.Form.GetValues("draw")[0];
                return Json(new { draw = Convert.ToInt32(draw), recordsTotal = recordsTotal, recordsFiltered = recordsFiltered, data = data }, JsonRequestBehavior.AllowGet);
            }
    
