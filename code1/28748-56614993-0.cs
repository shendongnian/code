        /// <summary>
        /// Pop value from top of string[] array
        /// </summary>
        public void PopStringArray(ref string[] array)
        {
            int newLength = array.Length;
			string[] temp = new string[array.Length];
			for (int i = array.Length - 1; i >= 1; i--)
			  	temp[i - 1] = array[i];
			
	        array = temp;
    	}
