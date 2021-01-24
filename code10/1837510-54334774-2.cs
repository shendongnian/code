    [CustomEditor(typeof(SoldierData))]
    public class SoldierEditor : Editor
    {
        private SerializedProperty life, autoAttack, skills/*, weapon*/;
        private bool showBaseProperties = true, showWeaponProperties = false;
    
        private void OnEnable()
        {
            life = serializedObject.FindProperty("life");
            autoAttack = serializedObject.FindProperty("autoAttack");
            skills = serializedObject.FindProperty("skills");
            //weapon = serializedObject.FindProperty("weapon");
        }
        public override void OnInspectorGUI()
        {
            showBaseProperties = EditorGUILayout.Foldout(showBaseProperties, "Basic settings:");
            if (showBaseProperties)
            {
                base.OnInspectorGUI();
            }
            serializedObject.Update();
            showWeaponProperties = EditorGUILayout.Foldout(showWeaponProperties, "Weapon settings");
            if (showWeaponProperties)
            {
                EditorGUILayout.PropertyField(autoAttack);
                EditorGUILayout.PropertyField(life);
            }
            EditorGUILayout.PropertyField(skills);
            serializedObject.ApplyModifiedProperties();
        }
    }
