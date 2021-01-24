    public Room : MonoBehaviour
    {
       public List<Requirement> Requirements;
       
       public bool CheckRequirements()
       {
          foreach (var requirement in Requirements)
          {
             if (requirement.Decision.State != requirement.State)
             {
                return false;
             }
          }
          return true;
       }
    }
