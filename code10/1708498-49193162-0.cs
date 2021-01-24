        public ActionResult RentListing()
        {
            if (Session["rentlist"] != null)
            {
                var list = (List<RootObject>)Session["rentlist"];
                return View(list);
            }
            else
            {
                var value = GetRentListing();
                var list = (List<RootObject>)Session["rentlist"];
                return View(list);
            }
        }
         [HttpGet]
        public async System.Threading.Tasks.Task<string> GetRentListing()
        {
            try
            {
                HttpClient client = new HttpClient();
                string AccessCode = ConfigurationManager.AppSettings["AccessCode"];
                string GroupCode = ConfigurationManager.AppSettings["GroupCode"];
                string Url = "http://www.airlist.com/v1.1/website.asmx/RentListings?AccessCode=" + AccessCode + "&GroupCode=" + GroupCode + "&unitId=" + "" + "&StartPriceRange=" + "" + "&EndPriceRange=" + "" + "&floorAreaMin=" + "" + "&floorAreaMax=" + "" + "&cityId=" + "" + "&unitTypeId=" + "" + "&BedroomsMin=" + "" + "&BedroomsMax=" + "" + "&CommunityId=" + "" + "";
                client.BaseAddress = new Uri(Url);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Url).Result;
                string data = "false";
                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
                    var list = new JavaScriptSerializer().Deserialize<dynamic>(json);
                    var d = ((list["RentListings"])["RentListing"]);
                    var lists = new JavaScriptSerializer().Serialize(d);
                    lists = lists.Replace("#cdata-section", "cdata");
                    var listss = new JavaScriptSerializer().Deserialize<List<RootObject>>(lists);
                    Session["rentlist"] = listss;
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    public class RootObject
    {
        public string Count { get; set; }
        public string Country { get; set; }
        public object State { get; set; }
        public string City { get; set; }
        public object District { get; set; }
       
    
    }
