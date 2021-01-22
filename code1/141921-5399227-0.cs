    catch (Exception ex)
            {
                // Errormessage for now, of course should be made user-friendly
                ModelState.AddModelError("_FORM", ex.InnerException.Message);
                string[] list = new string[] { "1", "2", "3", "4", "5" };
                SelectList ratings = new SelectList(list);
                ViewBag.Ratings = ratings;
                return View(companyRating);
            }
