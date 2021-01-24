    public class PlayerViewWindow : EditorWindow
    {
        private Camera PlayerViewCamera; // References a camera in the scene
    
        public void OnGUI()
        {
            if(PlayerViewCamera.targetTexture != null)
            {
                PlayerViewCamera.targetTexture.Release();
            }
    
            PlayerViewCamera.targetTexture = new RenderTexture((int)position.width, (int)position.height, 24, RenderTextureFormat.ARGB32);
            PlayerViewCamera.Render();
            GUI.DrawTexture(new Rect(0, 0, position.width, position.height), PlayerViewCamera.targetTexture);       
        }
    }
