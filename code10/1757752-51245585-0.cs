    public class RenderCameraToCubemap : Monobehaviour {
      public RenderTexture rt;
      void LateUpdate() {
        GetComponent<Camera>().RenderToCubemap(rt);
      }
    }
