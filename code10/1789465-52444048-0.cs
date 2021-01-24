    public class City
    {
        [Key]
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int sId { get; set; } // stateId
        public State state { get; set; }
    }
    public JsonResult GetCityList(int sId)
    {
        db.Configuration.ProxyCreationEnabled = false;
        List<City> listCity = db.Cities.Where(x => x.sId == sId).ToList();
        return Json(listCity,JsonRequestBehavior.AllowGet);
    }
    $(document).ready(function () {
        $("#sId").change(function () {
            $.get("/Home/GetCityList", { sId: $("#sId").val() }, function (data) {
                $("#cityId").empty();
                $.each(data, function (index, row) {
                    $("#cityId").append("<option value= '"+row.cityId+"'>"+ row.cityName+"</option>")
                });
            });
        })
    });
