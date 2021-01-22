        class ComplexNumber
        {
            public int RealPart { get; set; }
            public int ComplexPart { get; set; }
    
            public ComplexNumber(int real, int complex)
            {
                this.RealPart = real;
                this.ComplexPart = complex;
            }
    
            public ComplexNumber Add(ComplexNumber c)
            {
                return new ComplexNumber(this.RealPart + c.RealPart, this.ComplexPart + c.ComplexPart);
            }
        }
