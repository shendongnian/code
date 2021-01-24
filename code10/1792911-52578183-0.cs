      public ActionResult Index(string xmlResult)
      {
          var ser = new XmlSerializer(typeof(Availability));
          using (var sr = new StringReader(xmlResult))
          {
               var obj = (Availability)ser.Deserialize(sr);
               return View(obj);
          }
      }
