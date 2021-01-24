      [HttpPost, ActionName("CandidateCreate")]
        [ValidateAntiForgeryToken]
        public  IActionResult CandidateCreatePost([Bind("Name,Number,Profile,CV,CVID")] Candidate candidate, IFormFile CV)
        {
            if (ModelState.IsValid)
            {
                if (CV != null)
                {
                    if (CV.Length > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = CV.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                            
                        }
                        candidate.CVNAME = CV.FileName;
                        candidate.CV = p1;
                        }
                    }
                using (var applicationContext = new ApplicationContext())
                {
                    candidateRepository.Add(candidate);
                     candidateRepository.SaveChanges();
                    return RedirectToAction("Candidate");
                }
            }
            return View();
        }
