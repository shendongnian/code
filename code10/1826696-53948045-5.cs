        // In a MonoBehaviour attached to the Particles GameObject
        using UnityEngine.Experimental.VFX;
        ...
        // As a field in the MonoBehaviour
        public VisualEffect myEffect;
        ... 
        myEffect = GetComponent<VisualEffect>();
