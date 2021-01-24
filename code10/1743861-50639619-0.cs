    public abstract class Participant : MonoBehaviour {
        //By default, the race is along the z direction
        public virtual float GetDistanceTravelled(Vector3 startPoint) {
            return startPoint.z - transform.position.z;
        }
        //At every frame, my participants shall move. How they move depends on what the player and enemy subclasses implement it.
        protected virtual void Update() {
            Move();
        }
        //Your participants will need to move, but players move with keyboard control, while enemies move programmatically. So we let the subclasses implement them.
        protected abstract void Move();
    }
