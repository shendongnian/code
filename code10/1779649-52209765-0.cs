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
            var addedObjects = Resources.FindObjectsOfTypeAll<MyScript>().Where(x => x.isAdded < 2);
            foreach (var item in addedObjects)
            {
                item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 2);
                item.isAdded++;
            }
        }
    }
