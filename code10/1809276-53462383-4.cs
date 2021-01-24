    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Matrix : MonoBehaviour {
        
        //declare the structure that will store the data
        public TileData tileData = new TileData();    
    
        //those are public so you could make the matrix with the size you want..
        //..ideally dynamically call it from your python file requisits
        public int horizontalMatrixSize = 10;  
        public int verticalMatrixSize = 10;
    
        // Use this for initialization
        void Start()
        {        
            //Create the matrix structure and fill it
            tileData.rows = new TileData.rowData[horizontalMatrixSize];
            for (int i = 0; i < tileData.rows.Length; i++)
            {
                tileData.rows[i].row = new TileData.cell[verticalMatrixSize];
                for (int u = 0; u < tileData.rows[i].row.Length; u++)
                {                
                    tileData.rows[i].row[u].value = GetValuesFromPythonFileOrWhatever();
                    tileData.rows[i].row[u].type = GetValuesFromPythonFileOrWhatever();
                }
            }
        }
        
    }
