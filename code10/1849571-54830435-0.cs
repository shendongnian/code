    public class Perspective_changer : MonoBehaviour 
    {
        private void Update () 
        {
            var objects = FindObjectsOfType<Layer_orderer>();librarian = GameObject.Find("Librarian");
            foreach(var layer in objects)
            {
                layer.y_pos = transform.position.y;
            }
        }
    }
    
