    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    
    public class HierarchyMonitorWindow : EditorWindow
    {
        [MenuItem("Window/Hierarchy Monitor")]
        static void CreateWindow()
        {
            EditorWindow.GetWindow<HierarchyMonitorWindow>();
        }
    
        void OnHierarchyChange()
        {
            var addedObjects = Resources.FindObjectsOfTypeAll<MyScript>()
                                        .Where(x => x.isAdded < 2);
            foreach (var item in addedObjects)
            {
                //if (item.isAdded == 0) early setup
                
                if (item.isAdded == 1) {
                    
                    // do setup here,
                    // will happen just after user releases mouse
                    // will only happen once
                    Vector3 p = transform.position;
                    item.transform.position = new Vector3(p.x, 2f, p.z);
                }
                // finish with this:
                item.isAdded++;
            }
        }
    }
