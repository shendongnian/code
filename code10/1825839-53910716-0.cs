    #if UNITY_EDITOR
    using UnityEngine;
    using UnityEditor;
    public class AssetbundleCreator : MonoBehaviour
    {
    [MenuItem("Assets/Build Assetbundle")]
     static void Create()
     {
        BuildPipeline.BuildAssetBundles("Assets/", // path where your assetbundle will be saved
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.Android); // or any platform you want.
     }
    }
    #endif
