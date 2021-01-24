    public class DevTools : EditorWindow
    {
    Object workLight = default;
    
    [MenuItem("Window/DevTools")]                                                       
    public static void ShowWindow()                                                     
    {
        GetWindow<DevTools>("Development Tools");      
    }
    private void OnGUI()                                                                
    {
        GUILayout.Label("This is the development tools.", EditorStyles.boldLabel);  
        if (GUILayout.Button("Working Light"))
        {
            if (workLight == null)
            {
                ShowNotification(new GUIContent("No light selected"));
            }
            else
            {
                var light = GameObject.Find("Work Light");
                if (light == null)
                {
                    ShowNotification(new GUIContent("Selected object is not a light"));
                    return;
                }
                else
                {
                    light.gameObject.GetComponent<Light>().enabled = !light.gameObject.GetComponent<Light>().enabled;
                }
            }
        }
    }
}
