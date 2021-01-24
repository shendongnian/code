    public class HierarchyChart
    {
        public object[] cols { get; set; }
        public object[] rows { get; set; }
    }
    public JsonResult HierachyChart(int id)
    {
        var hierarchyChart = new HierarchyChart();
        hierarchyChart.cols = new object[] { "Employee Name", "Salary" }
        hierarchyChart.rows = new object[] {
            new object[] { "Bob", 35000 },
            new object[] { "Alice", 44000 },
            new object[] { "Frank", 27000 },
            new object[] { "Floyd", 92000 },
            new object[] { "Fritz", 18500 }
        };
        return this.Json(hierarchyChart , JsonRequestBehavior.AllowGet);
    }
