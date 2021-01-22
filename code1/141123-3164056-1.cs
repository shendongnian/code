    public class MyContactListener : ContactListener {
        // Called when intersection begins.
        void BeginContact(Contact contact) {
            // ...
            // Make some indication that the two bodies collide.
            // ...
        }
        // Called when the intersection ends.
        void EndContact(Contact contact) {
            // ...
            // Make some indication that the two bodies no longer collide.
            // ...
        }
        // Called before the contact is processed by the dynamics solver.
        void PreSolve(Contact contact, Manifold oldManifold) {}
        // Called after the contact is processed by the dynamics solver.
        void PostSolve(Contact contact, ContactImpulse impulse) {}
    }
