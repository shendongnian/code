    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Agency agency, string[] selectedOptions)
        {
            var dbTable = "AgencySector";
            
            if (agency.id == 0)
            {
                agency.created = DateTime.Now;
                agency.createdby = 1;
                agency.createdbytype = "A";
                agency.lastupdated = DateTime.Now;
                agency.lastupdatedby = 1;
                agency.lastupdatedbytype = "A";
                agency.deleted = false;
                
                UpdateAgencySectors(selectedOptions, agency, dbTable);
                _db.Agencies.Add(agency);
                _db.SaveChanges();
                return Json(new {success = true, message = "Saved successfully"}, JsonRequestBehavior.AllowGet);
            }
            
            _db.Agencies.Attach(agency); //attaches chosen agency
            UpdateAgencySectors(selectedOptions, agency, dbTable);
            _db.Entry(agency).CurrentValues.SetValues(typeof(AgencySectorViewModel));
            //adds relationship found in UpdateAgencySectors
            agency.lastupdated = DateTime.Now; //updates modified time
            _db.Entry(agency).State = EntityState.Modified;         
            _db.SaveChanges();
            return Json(new {success = true, message = "Updated successfully"}, JsonRequestBehavior.AllowGet);
        }
        
        private void UpdateAgencySectors(string[] selectedOptions, Agency agency, string dbTable)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Delete"].ConnectionString);           
            con.Open();
            var cmd = new SqlCommand("Delete from " + dbTable  +
                                            " where " + dbTable + " = " + agency.id, con);
            cmd.ExecuteNonQuery();
            con.Close();
            
            if (selectedOptions == null)
            {
                return;
            }
            var selectedOptionsHs = new HashSet<string>(selectedOptions);
            var agencySectors = new HashSet<int>
                (agency.Sectors.Select(b => b.id));
            
            foreach (var sector in _db.Sectors)
            {
                if (!selectedOptionsHs.Contains(sector.id.ToString())) continue;
                if (!agencySectors.Contains(sector.id))
                {
                    agency.Sectors.Add(sector);
                }
            }
        }
