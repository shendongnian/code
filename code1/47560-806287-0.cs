        public ActionResult JsonExceptionHandler(Func<object> action)
        {
                try
                {
                        var res = action();
                        return res == null ? JsonSuccess() : JsonSuccess(res);
                }
                catch(Exception exc)
                {
                        controller.ControllerContext.HttpContext.AddError(exc);
                        return JsonFailure(new {errorMessage = exc.Message});
                }
        }
