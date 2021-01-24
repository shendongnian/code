    [HttpGet]
    public HttpResponseMessage Get(int isxmlorJson)
    {
          StudentPersistent tp = new StudentPersistent();
          tp = //Get data from Business Layer
          var data = new ObjectContent<StudentPersistent>(tp,
                        ((isxmlorJson== 1) ? Configuration.Formatters.XmlFormatter :
                                    Configuration.Formatters.JsonFormatter));
        return new HttpResponseMessage()
        {
             Content = data
        };    
    }
