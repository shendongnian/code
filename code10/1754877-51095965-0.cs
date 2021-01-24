    public static bool Raycast(Ray ray);
    public static bool Raycast(Vector3 origin, Vector3 direction);
    public static bool Raycast(Ray ray, float maxDistance);
    public static bool Raycast(Ray ray, out RaycastHit hitInfo);
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance);
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo);
    public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance);
    public static bool Raycast(Ray ray, float maxDistance, int layerMask);
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask);
    public static bool Raycast(Ray ray, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
    public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask);
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
    public static bool Raycast(Vector3 origin, Vector3 direction, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction);
       
