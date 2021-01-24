    public class MyController
    {
      public ActionResult DoesNotNeedUserInfo()
      {
      }
      [AddUserToViewDataFilter]
      public ActionResult NeedsUserInfo()
      {
      }
    }
