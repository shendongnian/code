    public class AssistedController : Controller
    {
        // GET: Assisted
        AddressList model;
        public ActionResult Index()
        {
            if (TemData.ContainsKey("address"))
            {
                model = TempData["address"] as AddressList;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult GetAddresses(string postcode)
        {
            model = new AddressList();
            if (postcode == null || postcode == "")
            {
                return RedirectToAction("/Index/");
            }
            if (TemData.ContainsKey("address"))
            {
                model = TempData["address"] as AddressList;
                return View(model);
            }
            //call enviroweb web service
            AddressWeb ew = new AddressWeb();
            //extract address values from the XML returned from web service
            XmlNode xml = ew.GetAddress(", , , , " + postcode);
            foreach (XmlElement addressInfo in xml)
            {
                foreach (XmlElement teset in addressInfo["Addresses"])
                {
                    //add each address item found to the list
                    model.listone.Add(new AddressResults
                    {
                        FullAddress = teset["fulladdress"].InnerText,
                        Lat = teset["Lat"].InnerText,
                        Lon = teset["Long"].InnerText,
                        addLine1 = teset["addline1"].InnerText,
                        addLine2 = teset["addline2"].InnerText,
                        addLine3 = teset["addline3"].InnerText,
                        addLine4 = teset["addline4"].InnerText,
                        Town = teset["Town"].InnerText,
                        postcode = teset["postcode"].InnerText,
                        Ownership = teset["Ownership"].InnerText,
                        WeekNumber = teset["WeekNumber"].InnerText
                    });
                }
            }
            TempData["address"] = model;
            //return the list and model back to the index view
            return View("Index", model);
        }
    }
