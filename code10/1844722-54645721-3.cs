    [RequireComponent(typeof(ContentSizeFitter), typeof(VerticalLayoutGroup))]
    public class GridWith2Columns : MonoBehaviour
    {
        public Sprite sprite;
    
        private HorizontalLayoutGroup _currentRow;
        private GameObject placeholder;
        private int itemCounter;
    
        private void Awake()
        {
            var verticle = GetComponent<VerticalLayoutGroup>() ? GetComponent<VerticalLayoutGroup>() : gameObject.AddComponent<VerticalLayoutGroup>();
            verticle.childAlignment = TextAnchor.UpperCenter;
            verticle.childControlHeight = true;
            verticle.childControlWidth = true;
            verticle.childForceExpandHeight = true;
            verticle.childForceExpandWidth = true;
    
            var sizeFitter = GetComponent<ContentSizeFitter>() ? GetComponent<ContentSizeFitter>() : gameObject.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    
        public void AddChild()
        {
            // if exists remove placeholder
            if (placeholder)
            {
                if (Application.isPlaying) Destroy(placeholder);
                else DestroyImmediate(placeholder);
            }
    
            // Every second item we add a new horizontal row
            // starting with the first ;)
            if (itemCounter % 2 == 0)
            {
                var newRowObj = new GameObject("row", typeof(RectTransform), typeof(HorizontalLayoutGroup));
                newRowObj.transform.SetParent(transform, false);
                _currentRow = newRowObj.GetComponent<HorizontalLayoutGroup>();
                _currentRow.childAlignment = TextAnchor.UpperCenter;
                _currentRow.childControlHeight = false;
                _currentRow.childControlWidth = true;
                _currentRow.childForceExpandHeight = true;
                _currentRow.childForceExpandWidth = true;
            }
    
            // Add a new item child to the current
            // I use some example settings like sprite and color just to show how it works
            // you can ofcourse also simply instantiate a prefab
            var newItem = new GameObject("item", typeof(RectTransform), typeof(Image), typeof(StayQuadratic));
            newItem.transform.SetParent(_currentRow.transform, false);
            var itemImage = newItem.GetComponent<Image>();
            itemImage.color = Color.red;
            itemImage.sprite = sprite;
    
            newItem.GetComponent<RectTransform>().sizeDelta = Vector2.one * _currentRow.GetComponent<RectTransform>().rect.width / 2;
    
            itemCounter++;
    
            // add an invisble filler in case of impair child count
            if (itemCounter % 2 != 0)
            {
                placeholder = new GameObject("placeholder", typeof(RectTransform), typeof(StayQuadratic));
                placeholder.transform.SetParent(_currentRow.transform, false);
                placeholder.GetComponent<RectTransform>().sizeDelta = Vector2.one * _currentRow.GetComponent<RectTransform>().rect.width / 2;
            }
        }
    
        // Don't mind this further it is just for adding the 
        // AddChild button to the inspector for the example
        [CustomEditor(typeof(GridWith2Columns), true)]
        private class AddchildsEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
    
                EditorGUILayout.Space();
    
                if (GUILayout.Button("Add Child"))
                {
                    ((GridWith2Columns)target).AddChild();
                }
            }
        }
    }
    
