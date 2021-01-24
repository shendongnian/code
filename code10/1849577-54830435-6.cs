    public class Perspective_changer : MonoBehaviour 
    {
        private void Update () 
        {
            var layerOrderers= FindObjectsOfType<Layer_orderer>();librarian = GameObject.Find("Librarian");
            foreach(var layer in layerOrderers)
            {
                layer.y_pos = transform.position.y;
            }
        }
    }
    
