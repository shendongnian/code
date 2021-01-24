		void OnGUI() {
			if (objectThatFollowsMouse != null) {
				SceneView.onSceneGUIDelegate -= OnSceneGUI;
				SceneView.onSceneGUIDelegate += OnSceneGUI;
			}
			else { SceneView.onSceneGUIDelegate -= OnSceneGUI; }
		}
		void OnSceneGUI(SceneView sceneView) {
              ...
         }
