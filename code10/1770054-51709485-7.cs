    public GameManager : MonoBehaviour
    {
       public void SetDecisionToActive(Decision decision)
       {
          decision.State = DecisionState.Active;
       }
    
        public void SetDecisionToInactive(Decision decision)
       {
          decision.State = DecisionState.Inactive;
       }
       // etc...
    }
