    [HttpGet]
    public JsonResult NewData()
    {
        List<mydatasample> mydata = new List<mydatasample>(); 
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test2", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        mydata.Add(new mydatasample { bookName = "test1", publisherName = "yum3", publishYear = 2018 });
        return Json(mydata, JsonRequestBehavior.AllowGet);
    }
