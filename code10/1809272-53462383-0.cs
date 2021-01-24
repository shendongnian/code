    using UnityEngine;
    using System.Collections;
    
    [System.Serializable]
    public class TileData
    {
        /*
         * rows
            [rowData][rowData][rowData]
            [cell]  ->value
                    ->type
            [cell]  ->value
                    ->type
            [cell]  ->value
                    ->type
        */
    
        [System.Serializable]
        public struct cell
        {
            public float value;
            public string type;
        }
    
    
        [System.Serializable]
        public struct rowData
        {
            public cell[] row;
        }
        
        public rowData[] rows;
        
    }
