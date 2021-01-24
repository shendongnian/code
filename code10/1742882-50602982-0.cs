    public class CollisionSystem
    {
        Public void HandleCollision(IGameObject[] objects)
        {
            foreach (IGameObject obj in objects)
            {
                //call the function that tells the object it collided
                obj.CollisionDetected()
            }
        }
    }
