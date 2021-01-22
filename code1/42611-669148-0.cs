    public PDataContext DataContext {
       get {
          PDataContext result = HttpContext.Current["PData"];
          if (result == null) {
             result = new PDataContext(TUtil.GetConnectionString());
             HttpContext.Current["PData"] = result;
          }
          return result;
       }
    }
