            public class HierarchyChart
        {
            public object[] cols { get; set; }
            public object[] rows { get; set; }
        }
        public JsonResult HierachyChart(int id)
        {
            var hierarchyChart = new HierarchyChart
            {
                cols = new object[]
                {
                    new { id = "task", type = "string", label = "Employee Name" },
                    new { id = "startDate", type = "date", label = "Start Date" }
                },
                rows = new object[]
                {
                    new { c = new object[] { new { v = "Bob" }, new { v = 35000 } } },
                    new { c = new object[] { new { v = "Alice" }, new { v = 44000 } } },
                    new { c = new object[] { new { v = "Frank" }, new { v = 28000 } } },
                    new { c = new object[] { new { v = "Floyd" }, new { v = 92000 } } },
                    new { c = new object[] { new { v = "Fritz" }, new { v = 18500 } } }
                }
            };
            return this.Json(hierarchyChart, JsonRequestBehavior.AllowGet);
        }
