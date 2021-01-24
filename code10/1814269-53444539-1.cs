    public ActionResult channel_index()
            {
                List<Full> model = new List<Full>();
                //you need to do the query with ToList
                var list = db.Fulls.ToList();
        
                foreach (var item in list )
                {
                    var initedF = new Full({
                       Channel = item.Channel, 
                       Program = item.Program
                    });
                    //f.Channel = item.Channel;
                    //f.Program = item.Program;
                    model.Add(initedF);
                }
                return View(model);
            }
