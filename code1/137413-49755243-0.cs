        // using form y = mx+b
        // or y=Slope(x)=yIntercept
        public int GradeLevel { get; set; }
        public float Slope { get; set; }
        public float yIntercept { get; set; }
     
        public float GetYGivenX(float x)
        {
            float result = 0;
            result = (Slope * x) + yIntercept;
            return result;
        }
        public GradeLineEquation(int gradelevel,float slope,float yintercept)
        {
            this.GradeLevel = gradelevel;
            this.Slope = slope;
            this.yIntercept = yintercept;
        }
        
    }
