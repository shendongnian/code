    IList<SelectListItem> items = new List<SelectListItem>();
    foreach (var item in db.Kategoris.ToList())
    {
      SelectListItem sellist = new SelectListItem();
      sellist.Value = item.code.ToString();
      sellist.Text = item.name;
      items.Add(sellist);
    }
    ViewBag.KategoriId = items; // at the end this item should be list of `SelectListItem`
