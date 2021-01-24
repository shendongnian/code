    public class AddInventory : EditorWindow {
    
        public Inventory target;
    
        [MenuItem("Inventory/Add items")]
        public static void ShowWindow()
        {
            GetWindow<AddInventory>("Add items");
        }
    
         void OnGUI()
        {
            GUILayout.Label("Add items to  inventory", EditorStyles.boldLabel);
    
            target = (Inventory)EditorGUILayout.ObjectField("Inventory thingy", target, typeof(Inventory));   
    
            if (GUILayout.Button("I am button!"))
            {
                Debug.Log(target.thing);    
            }
        }
    }
