    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Matrix : MonoBehaviour {
        //declare the structure that will store the data
        [SerializeField] private float[,] grayscaleBidimensional = null;
    
        //those are public so you could make the matrix with the size you want..
        //..ideally dynamically call it from your python file requisits
        public int horizontalMatrixSize = 10;  
        public int verticalMatrixSize = 10;
    
        // Use this for initialization
        void Start()
        {        
            //Create the matrix structure and fill it
            tileData.rows = new TileData.rowData[horizontalMatrixSize];
            
            grayscaleBidimensional = new float[horizontalMatrixSize, verticalMatrixSize];
            for (int x = 0; x < horizontalMatrixSize; x++)
            {
                for (int y = 0; y < verticalMatrixSize; y++)
                {
                    grayscaleBidimensional[x, y] = GetValuesFromPythonFileOrWhatever();
                }
            }
        }
        
    }
