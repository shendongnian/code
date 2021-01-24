            if (ModelState.IsValid)
            {             
              
                _genericRepository.Add(department);
                await _genericRepository.SaveChangesAsync();
                return Json(department);
            }
            return Json(department);
        }`
