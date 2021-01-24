    private static void OnSceneGUI(SceneView sceneView)
    {
        Vector3 distanceFromCam = new Vector3(Camera.main.transform.position.x, 
                                                    Camera.main.transform.position.y, 
                                                        0);
        Plane plane = new Plane(Vector3.forward, distanceFromCam);
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            //Get the point that is clicked
            resets = ray.GetPoint(enter);
            //Debug.Log("Mouse Pos" + resets);
        }
    }
