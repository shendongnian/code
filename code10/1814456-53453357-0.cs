    public static class ExtensionMethod
    {
        public static bool IsTouching(this Collider collider, Collider otherCollider)
        {
            return CollisionDetection.IsTouching(collider.gameObject, otherCollider.gameObject);
        }
    
        public static bool IsTouching(this GameObject collider, GameObject otherCollider)
        {
            return CollisionDetection.IsTouching(collider, otherCollider);
        }
    }
