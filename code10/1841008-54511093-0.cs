    [CustomEditor(typeof(XY)]
    public class XYEditor : Editor
    {
        XY _target;
        SerializedProperty list;
        // Called when the class gains focus
        private void OnEnable()
        {
            _target = (XY) target;
            //Link the SerializedProperty
            list = serializedObject.FindProperty("listOfDictionaryKeys");
        }
        public override void OnInpectorGUI()
        {
            //whatever your inspector does
        }
        // Called when the component looses focus
        private void OnDisable()
        {
            serializedObjet.Update();
            // empty list
            list.ClearArray;
            // Reading access to the target's fields is okey 
            // as long as you are sure they are set at the moment the editor is closed
            foreach(var key in _target.myDoctionary.keys)
            {
                list.AddArrayElementAtIndex(list.arraySize);
                var element = list.GetArrayElementAtIndex(list.arraySize - 1);
                element.stringValue = key;
            }
            serialzedObject.ApplyModifiedProperties;
        }
    }
