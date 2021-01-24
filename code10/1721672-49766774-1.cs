    class PlayerClass : MonoBehaviour
    {
        float timer = 0.0f;
        float cooldownTime = 1.0f;
        void Update() {
            if(timer > cooldownTime) { 
                if(Input.GetMouseButtonDown(0)) {
                    Attack();
                    timer = 0;
                }
            }
            
            if(timer < cooldownTime + 1) // Add some leaniency for inaccurate floating points.
                timer += time.DeltaTime;
        }
    }
