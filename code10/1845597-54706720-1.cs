    public class Road
    {
        public string RoadID { get; set; }
    }
    [HttpPost]
    public async Task<ActionResult> DeleteRoad([System.Web.Http.FromBody]Road road)
    {
        Debug.WriteLine($"Road ID = { road.RoadID }");
        return RedirectToAction("Index");
    }
