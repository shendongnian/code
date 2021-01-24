    public ActionResult channel_index()
            {
                List<Full> model = new List<Full>();
                //you need to do the query with ToList
                var list = db.Full.ToList();
        
                foreach (var item in list )
                {
                    var initedF = new Full({
                       Channel = Regex.Replace(item.Channel, @"s", ""), 
                       Program = Regex.Replace(item.Program, @"s", "")
                    });
                    //f.Channel = item.Channel;
                    //f.Program = item.Program;
                    model.Add(initedF);
                }
                return View(model);
            }
