        public bool AddPoint(uint time, object value)
        {
            bool success = false;
            int index = 0;
            Debug.Assert(_selectedParameterName != null, "RecipeBusinessObject.InsertPointAtTime() _selectedParameterName = null");
            Debug.Assert(_currentRecipe != null, "RecipeBusinessObject.InsertPointAtTime() _currentRecipe = null");          
            Debug.Assert(CurrentParameterTable != null, "RecipeBusinessObject.InsertPointAtTime() CurrentParameterTable = null");
            Debug.Assert(index >= 0, "RecipeBusinessObject.InsertPoint(), index out of range, index = " + index.ToString());
            Debug.Assert(index <= CurrentParameterTable.Rows.Count, "RecipeBusinessObject.InsertPoint(), index out of range, index = " + index.ToString());
            DataRow newRow = CurrentParameterTable.NewRow();
            <snip>
