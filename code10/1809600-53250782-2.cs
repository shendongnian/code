    public class ChangeShaderRenderingModes : EditorWindow
    {
        //store mode
        static BlendMode currentMode = BlendMode.Opaque;
    	
    	static Dictionary<BlendMode, BlendMode> dict = new Dictionary<BlendMode, BlendMode>();
    	
    	
        public void Awake()
        {
            dict.Add(BlendMode.Opaque, BlendMode.Cutout);
    		dict.Add(BlendMode.Cutout, BlendMode.Fade);
    		dict.Add(BlendMode.Fade, BlendMode.Transparent);
    		dict.Add(BlendMode.Transparent, BlendMode.Opaque);
        }
    	
    	
        public enum BlendMode
        {
            Opaque,
            Cutout,
            Fade,
            Transparent
        }
    
        static Material material;
        static Material objectMat;
        static int modeIndex = 0;
    
        [MenuItem("Tools/Change Rendering Modes")]
        public static void ShowWindow()
        {
            GetWindow<ChangeShaderRenderingModes>("ChangeRenderingModes");
        }
    
        private void OnGUI()
        {
            if(GUI.Button(new Rect(50,50,50,50), "Switch Mode"))
            {
                var objects = Selection.objects;
    
                Shader shader = Shader.Find("Standard");
                material = new Material(shader);
    
                if (modeIndex == 4)
                    modeIndex = 0;
    				
                // take out the parameter
                ChangeRenderMode(material);
    
                GameObject go = GameObject.Find("test");
    
                objectMat = go.GetComponent<Renderer>().sharedMaterial;
                objectMat = material;
                go.GetComponent<Renderer>().sharedMaterial = material;
            }
        }
    
        public static void ChangeRenderMode(Material standardShaderMaterial)
        {
            switch (blendMode)
            {
                ....
            }
    		// set next mode
    		currentMode = dict[currentMode];
        }
    }
