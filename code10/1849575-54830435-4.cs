    public class Perspective_changer : MonoBehaviour 
    {
        Layer_orderer[] layerOrderers;
        private void Start()
        {
            layerOrderers = FindObjectsOfType<Layer_orderer>();
        }
        private void Update () 
        {
            foreach(var layer in layerOrderers)
            {
                layer.y_pos = transform.position.y;
            }
        }
    }
