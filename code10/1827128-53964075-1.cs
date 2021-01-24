    public class user : MonoBehaviour
    {
        ...
        void Update()
        {
            // Stuff that should happen on every frame, 
            // e.g., checking if this character is clicked on
            if (!isActiveCharacter) return;
            
            // Stuff that should only happen when character is selected 
            if(Input.GetKey(KeyCode.W))
            ...
