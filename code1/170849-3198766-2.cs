        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Example(IList<MyData> MyData)
        {
            // the MyData parameter will automatically be populated by the default ModelBinder using the values stored in the form collection (the posted data).
        }
