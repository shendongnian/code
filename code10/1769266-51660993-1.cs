    public class Spawner : MonoBehaviour {
        public Card cardPrefab;  // Instantiate will spawn this correctly and return the attached component to you.  
                                 // Less prone to error for this specific script since we are expecting a prefab
                                 // with a card script attached.
    
        // Spawn Method
        void SpawnCard(float x, float y, float z, int value, int suitValue)
        {
            Card newCard = instantiate(cardPrefab, new Vector3(x, y, z), transform.rotation);
            newCard.gameObject.name = "someName";
            newCard.faceValue = value;
            newCard.suitValue = suitValue;
        }
    
    }
