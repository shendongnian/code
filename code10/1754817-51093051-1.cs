    public ActionResult Download(string fileGuidList, string fileGuid, int id, string returnUrl)
    {
        string[] items = fileGuidList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
          foreach(var item in items)
          {
              fileGuid = item;
          }
    }
