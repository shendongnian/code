    class ExcelRange 
    {
    	public bool MoveNext()
    	{
    		_index++;
    		//...
            if (...) 
            {
    		   GetStartIndexEnum(_fromRow, _fromCol, _toRow, _toCol);
    		   //...
               GetNextIndexEnum(_fromRow, _fromCol, _toRow, _toCol);
            }
    	}
    	
    	object IEnumerator.Current
    	{
    		get
    		{
    			return /*...*/ _worksheet._cells[_index] as ExcelCell /*...*/
    		}
    	}
    }
