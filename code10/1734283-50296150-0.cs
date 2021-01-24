	using UnityEditor;
	using UnityEngine;
	public class MainWindow : EditorWindow {
		private float floatFieldVal;    
		private Rect groupFloatFieldRect;
		[MenuItem("Examples/Test")]
		static void Init() {
			MainWindow window = (MainWindow)GetWindow(typeof(MainWindow), false, "My Empty Window");
			window.Show();
		}
		
		
		void OnGUI() {
			EditorGUILayout.BeginHorizontal(); {
				EditorGUILayout.BeginVertical(); { 
					GUILayout.Button("Button 1");
					GUILayout.Button("Button 2");
					GUILayout.Button("Button 3");
				} EditorGUILayout.EndVertical();
				EditorGUILayout.BeginVertical(GUILayout.Width(300)); { 
					// never load asset in the loop :)
					string assetFullPath = "Assets/Editor/Test.guiskin";
					var fakeFieldGUISkin = (GUISkin)AssetDatabase.LoadAssetAtPath(assetFullPath, typeof(GUISkin));
					GUIStyle fakeFieldStyle = fakeFieldGUISkin.GetStyle("test");
                    // place fake floatField right over a real field texture button
					Rect test = new Rect(groupFloatFieldRect);
					test.position = new Vector2(test.x + groupFloatFieldRect.width - 20, test.y + 3);
					test.size = new Vector2(20, 20);
					floatFieldVal = EditorGUI.FloatField(test,  "fake", floatFieldVal, fakeFieldStyle);
                    // Draw FloatField And Texture as a Group
					Rect groupRect = EditorGUILayout.BeginHorizontal(); {     
						// never create GUIStyle in the loop :)
						GUIStyle floatIconStyle = new GUIStyle(EditorStyles.toolbarButton) {
							fixedWidth = 20f,
							margin = new RectOffset(0, 0, 0, 0),
							padding = new RectOffset(0, 0, 0, 0)
						};
						floatFieldVal = EditorGUILayout.FloatField("", floatFieldVal);  
                        // It emulates a texture
						GUILayout.Label("◀▶", floatIconStyle)
						
                        // save group rect in a variable
						if (Event.current.type == EventType.Repaint)
							groupFloatFieldRect = groupRect;
					} EditorGUILayout.EndHorizontal();
				} EditorGUILayout.EndVertical();        
			} EditorGUILayout.EndHorizontal();
		}
		void OnInspectorUpdate() {
			Repaint();
		}    
	}
