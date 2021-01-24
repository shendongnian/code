    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "id,DeviceConfig_id,Device_statustypes_id,ConcremoteDevice_id,Employee_1,Employee_2,Device_statustypes_id,Sign_Date,Active")] DeviceStatus deviceStatus, ConcremoteDevice concremoteDevice)
            {
         
                if (ModelState.IsValid)
                {
                    db.Entry(deviceStatus).State = EntityState.Modified;
                    db.Entry(concremoteDevice).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["AlertMessage"] = "Device Edited Successfully";
                    return RedirectToAction("Index");
                }
                return View(deviceStatus);
            }
