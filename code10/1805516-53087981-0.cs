    public class PlayerViewWindow : EditorWindow
    {
        private Camera PlayerViewCamera; // References a camera in the scene
    
        public void OnGUI()
        {
            Vector2 size = new Vector2(position.width, position.width);
            //Get temporary RenderTexture
            RenderTexture tempRT = RenderTexture.GetTemporary((int)size.x, (int)size.y, 24, RenderTextureFormat.ARGB32);
            PlayerViewCamera.targetTexture = tempRT;
            PlayerViewCamera.Render();
            GUI.DrawTexture(new Rect(0, 0, size.x, size.x), PlayerViewCamera.targetTexture);
            //Release temporary RenderTexture
            RenderTexture.ReleaseTemporary(tempRT);
        }
    }
