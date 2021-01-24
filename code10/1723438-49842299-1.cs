    // A piece of barrier that gets destroyed once out of screen
    public sealed class BarrierPiece : MonoBehaviour
    {
        // Called once the object is no longer visible to any (scene editor included) camera
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
