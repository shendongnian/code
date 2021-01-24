       // In order NOT to reallocate the memory in the process, 
       // let's estimate imageData size in anvance.
       // Let us expect each item to be not more than of 20 characters
       var ImageData = new StringBuilder(2048 * 2048 * 20);
    
       foreach (var item in zDataDifference) {
         // We should add ',' before each item except the very first one
         if (ImageData.Length > 0)
           ImageData.Append(',');
    
         // Try to avoid creating a lot of small strings: item + ","
         ImageData.Append(item);
       }
    
       string result = ImageData.ToString();
