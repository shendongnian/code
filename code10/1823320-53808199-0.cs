    struct pixel1
            {
                public int y1;            
                public int x1;
                public Color color1;
            };
    
            struct Blob1//pixel list=blob
            {
                public List<pixel1> blob1;
                public int size;            
            };
    
            List<Blob1> bloblist = new List<Blob1>();  
    
    void runMethod1()
            {
                
                Blob1 b1 = new Blob1();
                b1.size = 1;
                pixel1 p1 = new pixel1();
                b1.blob1.Add(p1);
                
            }
