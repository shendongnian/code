    catch (Exception e)
    {
      log.Error(e);
      Response.StatusCode = 500;
      Response.TrySkipIisCustomErrors = true;
      return Json(new { message = e.Message } );
    }
