    public ActionResult Logon( string username, string password )
    {
         ...
         // Handle master page login
         if (Request.IsAjaxRequest())
         {
              if (success)
              {
                  return Json( new { Status = true, Url = Url.Action( "Index", "Home" ) } );
              }
              else
              {
                  return Json( new { Status = false, Message = ... } );
              }
         }
         else // handle login page logon or no javascript
         {
              if (success)
              {
                  return RedirectToAction( "Index", "Home" );
              }
              else
              {
                  ViewData["error"] = ...
                  return View("Logon");
              }
          }
      }
