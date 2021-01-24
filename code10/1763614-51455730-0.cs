       [HttpPost]
       [ValidateAntiForgeryToken]
       public GitJSON /*async Task<ActionResult>*/ Updateto([FromBody]GitJSON gitjson)
                {
                    return gitjson;
                }
