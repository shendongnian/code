    public ActionResult channel_index()
            {
                List<Full> model = new List<Full>();
                //you need to do the query with ToList
                var list = db.Fulls.ToList();
        
                foreach (var item in list )
                {
                    f.Channel = item.Channel;
                    f.Program = item.Program;
                    model.Add(f);
                }
                return View(model);
            }
