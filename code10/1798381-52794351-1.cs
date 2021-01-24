    public IActionResult Index(string CatId)
            {
              string catName=null;
                try
                {
               /*your code to get catname*/
                    if (catName != null)
                    {
                        return Ok(catName);
                    }
                    return NotFound();
                }
                catch (Exception e)
                {
                    return  InternalServerError(e);
                }
            }
