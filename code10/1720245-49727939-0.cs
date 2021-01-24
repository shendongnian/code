    public ActionResult Edit(List<Device_Pricelist> device_Pricelists)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var deviceConfig = db.DeviceConfig.Find(device_Pricelists.First().Device_config_id);
                deviceConfig.device_type_id = 13;
                deviceConfig.Active = true;
                deviceConfig.VersionNr++;
                deviceConfig.Date = DateTime.Now;
    
                db.DeviceConfig.Add(deviceConfig);
    
                foreach(var item in device_Pricelists)
                {
                    item.Device_config_id = deviceConfig.Device_config_id;
                }
    
                db.Device_Pricelists.AddRange(device_Pricelists);
    
                db.SaveChanges();
                TempData["SuccesMessage"] = "Data is Succesfully saved";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["AlertMessage"] = "Saving Data Failed, Try Again";
            }
        }
        return View(device_Pricelists);
    }
