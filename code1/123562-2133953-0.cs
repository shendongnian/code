        _array = new object[3];
        _result = new StringBuilder();
        //Populate array here
        foreach (object item in _array)
        {
	         ParseObject(item);
        }
        
        private void ParseObject(object value)
        { 
            if (value.GetType().IsArray)
            {
                IEnumerable enumerable = value as IEnumerable;
                foreach (object item in enumerable)
                {                    
                    ParseObject(item);
                }                
            }
            else
            {
                _result.Append(value.ToString() + "\n");
            }
        }
