    public class WhileOne : MonoBehaviour
    {
        private bool _theTrue;
        public bool theTrue
        {
            get { return _theTrue; }
            set
            {
                //Check if the bloolen variable changes from false to true
                if (_theTrue == false && value == true)
                {
                    // Do something
                    Debug.Log("Boolean variable chaged from:" + _theTrue + " to: " + value);
                }
                //Update the boolean variable
                _theTrue = value;
            }
        }
    
        void Start()
        {
            theTrue = false;
        }
    }
