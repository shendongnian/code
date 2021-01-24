    public class CreateItemViewModel
    {
        [Remote("IsSerialAvailable", "Value")]
        public string Serial { get; set; }
    }
    public class EditItemViewModel
    {
        [Remote("IsSerialAvailable", "Value", AdditionalFields = "ItemId")]
        public string Serial { get; set; }
        public int ItemId { get; set; }
    }
        public ActionResult IsSerialAvailable(string serial, int? itemId = null)
        {
            List<int> t = new List<int>();
            Item item;
            if (itemId.HasValue)
            {
                item = db.Items.SingleOrDefault(i => i.Serial == Serial && i.Id != itemId.Value);
               
            }
            else
            {
                item = db.Items.SingleOrDefault(i => i.Serial == Serial);
            }
            if (item != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
