    using System.Collections.Generic;
    using System.IO;
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;
    
    public class BlocksController : MonoBehaviour
    {
        private const string FILE_EXTENSION = ".xml";
    
        // fileName of the XML file (without extension)
        public string FileName;
    
        // prefab to be spawned for each block
        public GameObject BlockPrefab;
    
        // blocks in the scene
        public List<Transform> SceneBlocks;
    
        // blocks in the data
        public BlocksData BlocksData;
    
        private static string Folder
        {
            get
            {
    #if UNITY_EDITOR
                return Application.streamingAssetsPath;
    #else
                return Application.persistentDataPath;
    #endif
            }
        }
    
        private string FilePath
        {
            get
            {
                return Path.Combine(Folder, FileName + FILE_EXTENSION);
    
            }
        }
    
        [ContextMenu("Load Blocks")]
        public void LoadBlocks()
        {
            // Load from file
            BlocksData = BlocksData.Load(FilePath);
    
            // remove current scene blocks
            foreach (var sceneBlock in SceneBlocks)
            {
                // Have to se destroyImmediate in editmode
                if (Application.isEditor && !Application.isPlaying)
                {
                    DestroyImmediate(sceneBlock.gameObject);
                }
                else
                {
                    Destroy(sceneBlock.gameObject);
                }
            }
    
            // instantiate and setup prefab foreach block in data
            foreach (var block in BlocksData.Blocks)
            {
                var newBlock = Instantiate(BlockPrefab, block.Position, Quaternion.identity, transform);
                newBlock.name = block.Name;
    
                // don't forget to add it to the list of sceneBlocks
                SceneBlocks.Add(newBlock.transform);
            }
        }
    
        [ContextMenu("Save Blocks")]
        public void SaveBlocks()
        {
            // clear current data list
            BlocksData.Blocks.Clear();
    
            // add a block data foreach block in scene
            foreach (var sceneBlock in SceneBlocks)
            {
                BlocksData.Blocks.Add(new Block(sceneBlock.name, sceneBlock.position));
            }
    
            // finally write to file
            BlocksData.Save(FilePath);
    
    #if UNITY_EDITOR
            AssetDatabase.Refresh();
    #endif
        }
    }
