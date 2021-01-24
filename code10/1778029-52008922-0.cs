    public class HPsc
    {    
        private Component[] _images;
    
        void Start()
        {
            Images = GetComponents<Image>();
        }
        
        void Update()
        {
            // Assuming the order is correct, you could also make some sort of 
            // id property to search the array with.
            var green = images[0];
            var red = images[1];
            
            // Do something with the images.
        }
    }
