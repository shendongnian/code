        private void ConvertBitmap()
        {
            
           markedBitmap = Grayscale.CommonAlgorithms.RMY.Apply(markedBitmap);
           ApplyFilter(new FloydSteinbergDithering());
           
        }
        private void ApplyFilter(IFilter filter)
        {
            
            // apply filter
            convertedBitmap = filter.Apply(markedBitmap);
            
            
        }
