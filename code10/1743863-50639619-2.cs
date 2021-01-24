    public class RaceManager : MonoBehaviour {
        public List<Participant> participants; //you can add participants by dragging the gameobjects here from Unity's inspector, or add them in 
        public Vector3 startPoint; //again, set this in the inspector, or in Start()
    
        void Start() {
            //You can initialize startPoint, participants here. Or do it in the inspector
        }
    
        public void GetRaceDetails() {
            //Sort the list first. Check if the list is null first.. I will not do that here for clarity sake
            participants.Sort((p1, p2) => p1.GetDistanceTravelled(startPoint).Value.CompareTo(p2.GetDistanceTravelled(startPoint).Value)); //you can sort easily with lambda expressions
            
            //print the results here, you can iterate through the list and do a Debug.Log() or something
        }
    }
