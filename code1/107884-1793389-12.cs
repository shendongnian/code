        public ActionResult About() {
            List<FormMetaData> formItems = GetFormItems();
            return View(formItems);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult About(FormCollection form)
        {
            List<FormMetaData> formItems = GetFormItems();
            //TryUpdateModel(formItems);
            // update project members       
            foreach (var key in form.AllKeys) {
                if (key.ToString().StartsWith("TextBox")) {
                    string field = (key.ToString().Replace("TextBox", ""));
                    if (!string.IsNullOrEmpty(form.Get(key.ToString()))) {
                        formItems.Find(delegate(FormMetaData t) { return t.Field == field; }).Value = form.Get(key.ToString());
                    } 
                    else { }
                       // this.ProjectRepository.DeleteMemberFromProject(id, userId);
                }
            }
            ModelState.AddModelError("test", "this is a test error");
            if(ModelState.IsValid)
            {
                    ///
            }
            else
            {
                return View(formItems);
            }
            return View(formItems);
        }
        
        private List<FormMetaData> GetFormItems() {
                List<FormMetaData> output = new List<FormMetaData>();
                
                FormMetaData temp1 = new FormMetaData("TextBox",true,"temp1","displayText1");
                FormMetaData temp2 = new FormMetaData("TextBox", true, "temp2", "displayText2");
                output.Add(temp1);
                output.Add(temp2);
    
                return output;
            }
