    interface IAdminPage {
      public string AdminPageMethod();
    }
    
    interface IJQueryPage {
      public string JQueryPageMethod();
    }
    
    class AdminPage : IAdminpage {
      public string AdminPageMethod() {
        return "AdminPage result";
      }
    }
    class JQueryPage : IJQueryPage {
      public string JQueryPageMethod() {
        return "JQueryPage result";
      }
    }
    class AdminJQueryPage : IQueryPage, IAdminpage {
      IAdminPage adminPage = new AdminPage();
      IJQueryPage jqueryPage = new JQueryPage();
      public string AdminPageMethod() {
        return this.adminPage.AdminPageMethod();
      }
      public string JQueryPageMethod() {
        return this.adminPage.JQueryPageMethod();
      }
    }
