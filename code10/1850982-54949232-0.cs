    public ActionResult RefreshView(int id)
        {
            CWDataSetsEntities aCWDatasetEntity = new CWDataSetsEntities();
            int intCountryID = Convert.ToInt32(id);
            CWCountriesISOandCoordinates aCWCountry = new CWCountriesISOandCoordinates();
            aCWCountry = (from x in aCWDatasetEntity.CWCountriesISOandCoordinates where x.index == intCountryID select x).SingleOrDefault();
            string Country = aCWCountry.Country_Name;
            Models.PartitionViewModels Data = sb_admin_2.Web.ContentBuilder.PartitionBuilder.TradeVisual("Export", Country, "X2015");
            //sb_admin_2.Web.Models.PartitionViewModels.Javascript = Data;
            ViewBag.Data = Data;
            return PartialView("DataPartition", Data);
        }
