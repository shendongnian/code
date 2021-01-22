    using System.Linq;
    public static bool IsAllowed(int userID)
    {
      return new Personnel[]
          { Personnel.JohnDoe, Personnel.JaneDoe }.Contains((Personnel)userID);
    }
