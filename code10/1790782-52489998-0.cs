        using UnityEditor;
        using UnityEngine;
        
        namespace Draft
        {
            [ExecuteInEditMode]
            public class TestMouseDragObjectInSceneMonoBehaviour : MonoBehaviour
            {
                private GameObject _cube;
        
                private GameObject cube
                {
                    get
                    {
                        if (!_cube)
                        {
                            var c = Resources.Load<GameObject>("Obj/Cube");
                            _cube = Instantiate(c);
                        }
        
                        return _cube;
                    }
                }
        
                private void OnEnable()
                {
                    SceneView.onSceneGUIDelegate += OnSceneGUI;
                }
        
                private void OnSceneGUI(SceneView sceneview)
                {
                    var ev = Event.current;
                    if (ev.type == EventType.MouseMove)
                    {
                        cube.layer = LayerMask.NameToLayer("Ignore Raycast");
        //                Vector2 mousePos = Event.current.mousePosition;
        //                mousePos.y = sceneview.camera.pixelHeight - mousePos.y;
        //                var ray = sceneview.camera.ScreenPointToRay(mousePos);
                        var ray = HandleUtility.GUIPointToWorldRay(ev.mousePosition);
        //                cube.transform.position = ptr;
                        var hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit, 5))
                        {
                            cube.transform.position = hit.point;
        //                    Debug.Log(Vector3.Distance(ev.mousePosition, hit.point));
                        }
                        else
                        {
                            var ptr = ray.GetPoint(5);
                            cube.transform.position = ptr;
                        }
                    }
                }
        
                private void OnDisable()
                {
                    SceneView.onSceneGUIDelegate -= OnSceneGUI;
                }
        
                Vector3 GetMousePos(Event ev)
                {
                    return GUIUtility.ScreenToGUIPoint(ev.mousePosition);
                }
            }
    
    }
