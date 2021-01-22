    public class TopologicalSorter
    {
        #region - Private Members -
        private static int MAX_VERTS = 20;
        private char[] _vertices; // list of vertices
        private int[,] _matrix; // adjacency matrix
        private int _numVerts; // current number of vertices
        private char[] _sortedArray;
        #endregion
        #region - CTors -
        public TopologicalSorter()
        {
            _vertices = new char[MAX_VERTS];
            _matrix = new int[MAX_VERTS, MAX_VERTS];
            _numVerts = 0;
            for (int i = 0; i < MAX_VERTS; i++)
                for (int k = 0; k < MAX_VERTS; k++)
                    _matrix[i, k] = 0;
            _sortedArray = new char[MAX_VERTS]; // sorted vert labels
        }
        #endregion
        #region - Public Methods -
        public int AddVertex(char vertex)
        {
            _vertices[_numVerts++] = vertex;
            return _numVerts;
        }
        public void AddEdge(int start, int end)
        {
            _matrix[start, end] = 1;
        }
        public char[] Sort() // toplogical sort
        {
            int orig_nVerts = _numVerts;
            while (_numVerts > 0) // while vertices remain,
            {
                // get a vertex with no successors, or -1
                int currentVertex = noSuccessors();
                if (currentVertex == -1) // must be a cycle                
                    throw new Exception("ERROR: Graph has cycles");                    
               
                // insert vertex label in sorted array (start at end)
                _sortedArray[_numVerts - 1] = _vertices[currentVertex];
                deleteVertex(currentVertex); // delete vertex
            }
            // vertices all gone; return sortedArray
            return _sortedArray;          
        }
        #endregion
        #region - Private Helper Methods -
        // returns vert with no successors (or -1 if no such verts)
        private int noSuccessors() 
        {
            bool isEdge; // edge from row to column in adjMat
            for (int row = 0; row < _numVerts; row++)
            {
                isEdge = false; // check edges
                for (int col = 0; col < _numVerts; col++)
                {
                    if (_matrix[row, col] > 0) // if edge to another,
                    {
                        isEdge = true;
                        break; // this vertex has a successor try another
                    }
                }
                if (!isEdge) // if no edges, has no successors
                    return row;
            }
            return -1; // no
        }
        private void deleteVertex(int delVert)
        {
            // if not last vertex, delete from vertexList
            if (delVert != _numVerts - 1) 
            {
                for (int j = delVert; j < _numVerts - 1; j++)
                    _vertices[j] = _vertices[j + 1];
                for (int row = delVert; row < _numVerts - 1; row++)
                    moveRowUp(row, _numVerts);
                for (int col = delVert; col < _numVerts - 1; col++)
                    moveColLeft(col, _numVerts - 1);
            }
            _numVerts--; // one less vertex
        }
        private void moveRowUp(int row, int length)
        {
            for (int col = 0; col < length; col++)
                _matrix[row, col] = _matrix[row + 1, col];
        }
        private void moveColLeft(int col, int length)
        {
            for (int row = 0; row < length; row++)
                _matrix[row, col] = _matrix[row, col + 1];
        }
        #endregion
    }
....
