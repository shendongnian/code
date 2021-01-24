    using UnityEditor;
    // Loading the prefab this way only works in the editor.
    GameObject myPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Character.prefab");
    // Use this otherwise:
    // using UnityEngine;
    // GameObject myPrefab = Resources.Load<GameObject>("Prefabs/Character");
    // Note: The Prefabs folder has to be placed in a folder named Resources.
